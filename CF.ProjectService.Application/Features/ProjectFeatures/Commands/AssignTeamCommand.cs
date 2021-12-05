using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CF.ProjectService.Application.Common.Constants;
using CF.ProjectService.Application.Common.Enums;
using CF.ProjectService.Application.Common.Exceptions;
using CF.ProjectService.Application.Common.Interfaces;
using CF.ProjectService.Application.Common.Response;
using CF.ProjectService.Application.Entities;
using CF.ProjectService.Application.Features.ProjectFeatures.Dto;
using CF.ProjectService.Application.Features.UserFeatures.Dto;
using CF.ProjectService.Application.Services.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using DateTime = System.DateTime;

namespace CF.ProjectService.Application.Features.ProjectFeatures.Commands
{
    public class AssignTeamCommand : IRequest<CustomResponse<bool>>
    {
        public Guid RevisionId { get; set; }
        public EnviromentalDto Environmental { get; set; }
        public InfrastructureDto Infrastructure { get; set; }
        public TeamMembersDto TeamMembers { get; set; }

        public class AssignTeamCommandHandler : IRequestHandler<AssignTeamCommand, CustomResponse<bool>>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly ILoggedInUserService _loggedInUserService;
            private readonly IProjectNotificationService _projectNotificationService;
            private readonly IProjectDService _projectService;
            private readonly IProjectAuditLogService _auditLogService;
            public AssignTeamCommandHandler(
                IUnitOfWork unitOfWork,
                ILoggedInUserService loggedInUserService,
                IProjectNotificationService projectNotificationService,
                IProjectDService projectService,
                IProjectAuditLogService auditLogService
            )
            {
                _unitOfWork = unitOfWork;
                _loggedInUserService = loggedInUserService;
                _projectService = projectService;
                _projectNotificationService = projectNotificationService;
                _auditLogService = auditLogService;
            }
            public async Task<CustomResponse<bool>> Handle(AssignTeamCommand request, CancellationToken cancellationToken)
            {
                CustomResponse<bool> response = new CustomResponse<bool>();

                var projectInvision = await _unitOfWork.RevisionRepository.GetSingleAsync(x => x.Id == request.RevisionId,
                    source => source.Include(x => x.Enviromental)
                                  .Include(x => x.Project).ThenInclude(x => x.ProjectUsers)
                                  .Include(x => x.Project).ThenInclude(x => x.ProjectNatureDetails)
                                  .Include(x => x.InfrastructureData).ThenInclude(x => x.EvacuationOptionCondensates)
                                  .Include(x => x.InfrastructureData).ThenInclude(x => x.EvacuationOptionGas)
                                  .Include(x => x.InfrastructureData).ThenInclude(x => x.EvacuationOptionOils)
                                  .Include(x => x.InfrastructureData).ThenInclude(x => x.EvacuationOptionProducedWaters)
                                  .Include(x => x.WellCosts));

                if (projectInvision == null)
                {
                    response.Data = false;
                    response.IsSucceed = false;
                    response.Errors.Add(ExceptionMessages.ProjectNotFound);
                    return response;
                }

                // check permission
                if (!(await _projectService.CheckPermissionUserTrigger(projectInvision, ProjectTrigger.AssignTeam)))
                {
                    response.Data = false;
                    response.IsSucceed = false;
                    response.Errors.Add(ExceptionMessages.UserPermissionAction);
                    return response;
                }

                if ((request.Environmental != null && !request.Environmental.ValidationSaveChange())
                        || (request.Infrastructure != null && !request.Infrastructure.ValidationSaveChange()))
                {
                    response.Data = false;
                    response.IsSucceed = false;
                    response.Errors.Add(ExceptionMessages.SomeThingWrong);
                    return response;
                }

                //await _projectService.UpdateProjectStatus(request.RevisionId, RevisionStatus.Approved);
                if (request.Environmental.CheckChange(projectInvision.Enviromental))
                {
                    await _projectService.UpdateProjectEnviromentAsync(projectInvision, request.Environmental);
                    await _auditLogService.AddLogProjectAsync(projectInvision.Id, AuditLogStatus.UpdatedEnvironmental);
                }

                if (request.Infrastructure.CheckChange(projectInvision.InfrastructureData))
                {
                    await _projectService.UpdateProjectInfrastructureAsync(projectInvision, request.Infrastructure);
                    await _auditLogService.AddLogProjectAsync(projectInvision.Id, AuditLogStatus.UpdatedInfrastructure);
                }

                await _projectService.UpdateProjectTeamMembers(projectInvision, request.TeamMembers);

                await _unitOfWork.CommitAsync();
                _unitOfWork.DetachEntity<Project>(projectInvision.Project);
                await _projectService.UpdateProjectEntity(projectInvision);
                await _unitOfWork.CommitAsync();

                List<Guid> listUserId = new List<Guid>();
                listUserId.AddRange(request.TeamMembers.CostEngineers);
                listUserId.Add(request.TeamMembers.CostEngineerTechnical.Value);
                listUserId.AddRange(request.TeamMembers.FrontEndEngineers);
                listUserId.Add(request.TeamMembers.FrontEndEngineerTechnical.Value);

                await _projectNotificationService.TMAssignProjectAsync(projectInvision, listUserId);

                await _auditLogService.AddLogProjectAsync(projectInvision.Id, AuditLogStatus.TeamAssigned);
                await _unitOfWork.CommitAsync();

                response.Data = true;
                response.IsSucceed = true;
                return response;

                #region old version
                /*var revision =
                    await _unitOfWork.RevisionRepository.GetSingleAsync(x => x.Id == request.RevisionId, source => source.Include(x => x.Project));

                revision.Approve();
                revision.SubmittedByUserId = _loggedInUserService.Id;
                revision.SubmittedOn = DateTime.Now;
                _unitOfWork.RevisionRepository.Update(revision);

                await _unitOfWork.CommitAsync();

                await _projectService.UpdateProjectEntity(revision);
                return true;*/
                #endregion
            }
        }
    }
}
