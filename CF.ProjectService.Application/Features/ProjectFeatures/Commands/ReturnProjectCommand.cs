using CF.ProjectService.Application.Common.Enums;
using CF.ProjectService.Application.Common.Exceptions;
using CF.ProjectService.Application.Common.Interfaces;
using CF.ProjectService.Application.Common.Response;
using CF.ProjectService.Application.Entities;
using CF.ProjectService.Application.Features.ProjectFeatures.Dto;
using CF.ProjectService.Application.Services.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;

namespace CF.ProjectService.Application.Features.ProjectFeatures.Commands
{
    public class ReturnProjectCommand : IRequest<CustomResponse<bool>>
    {
        // public Guid? Id { get; set; }

        public Guid RevisionId { get; set; }

        //public ProjectInfoPostDto ProjectInfo { get; set; }

        public EnviromentalDto Environmental { get; set; }

        public InfrastructureDto Infrastructure { get; set; }

        public string RespondedRemarks { get; set; }


        //public IList<ProjectUserDto> ProjectUsers { get; set; }
        //public ProjectRevisionPostDto ProjectRevisions { get; set; }


        public class ReturnProjectCommandHandler : IRequestHandler<ReturnProjectCommand, CustomResponse<bool>>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IProjectDService _projectService;
            private readonly ILoggedInUserService _loggedInUserService;
            private readonly IHostingEnvironment _env;
            private readonly IProjectAuditLogService _auditLogService;
            private readonly IProjectNotificationService _projectNotificationService;

            public ReturnProjectCommandHandler(
                IUnitOfWork unitOfWork,
                IProjectDService projectService,
                ILoggedInUserService loggedInUserService,
                IProjectNotificationService projectNotificationService,
                IHostingEnvironment env,
                 IProjectAuditLogService auditLogService)
            {
                _unitOfWork = unitOfWork;
                _projectService = projectService;
                _loggedInUserService = loggedInUserService;
                _projectNotificationService = projectNotificationService;
                _env = env;
                _auditLogService = auditLogService;
            }

            public async Task<CustomResponse<bool>> Handle(ReturnProjectCommand request, CancellationToken cancellationToken)
            {
                CustomResponse<bool> response = new CustomResponse<bool>();

                var projectInvision = await _unitOfWork.RevisionRepository.GetSingleAsync(x => x.Id == request.RevisionId,
                    source => source.Include(x => x.Enviromental)
                                  .Include(x => x.Project).ThenInclude(x => x.ProjectUsers)
                                  .Include(x => x.Project).ThenInclude(x => x.ProjectNatureDetails)
                                  .Include(x => x.InfrastructureData).ThenInclude(x => x.EvacuationOptionCondensates)
                                  .Include(x => x.InfrastructureData).ThenInclude(x => x.EvacuationOptionGas)
                                  .Include(x => x.InfrastructureData).ThenInclude(x => x.EvacuationOptionOils)
                                  .Include(x => x.InfrastructureData).ThenInclude(x => x.EvacuationOptionProducedWaters));

                if (projectInvision == null)
                {
                    response.Data = false;
                    response.IsSucceed = false;
                    response.Errors.Add(ExceptionMessages.ProjectNotFound);
                    return response;
                }

                // check permission
                if (!(await _projectService.CheckPermissionUserTrigger(projectInvision, ProjectTrigger.Return)))
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

                await _projectService.UpdateProjectStatus(projectInvision, ProjectTrigger.Return, request.RespondedRemarks);
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

                await _unitOfWork.CommitAsync();
                _unitOfWork.DetachEntity<Project>(projectInvision.Project);

                await _projectService.UpdateProjectEntity(projectInvision);
                await _unitOfWork.CommitAsync();

                await _projectNotificationService.TMReturnProjectAsync(request.RevisionId);

                await _auditLogService.AddLogProjectAsync(projectInvision.Id, AuditLogStatus.Returned, request.RespondedRemarks);
                await _unitOfWork.CommitAsync();

                response.Data = true;
                response.IsSucceed = true;
                return response;

                #region backup ver 2
                /*CustomResponse<bool> response = new CustomResponse<bool>();

                var result = await _projectService.UpdateProjectInformation(request.RevisionId, null, request.Environmental, request.Infrastructure, RevisionStatus.Returned, request.RespondedRemarks);

                response.Data = result;
                response.IsSucceed = result;
                return response;*/
                #endregion 

            }
        }
    }
}
