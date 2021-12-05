using AutoMapper;
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
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;

namespace CF.ProjectService.Application.Features.ProjectFeatures.Commands
{
    public class SubmitProjectCommand : IRequest<CustomResponse<bool>>
    {
        // public Guid? Id { get; set; }

        public Guid? RevisionId { get; set; }

        public ProjectInfoPostDto ProjectInfo { get; set; }

        public EnviromentalDto Environmental { get; set; }

        public InfrastructureDto Infrastructure { get; set; }




        //public IList<ProjectUserDto> ProjectUsers { get; set; }
        //public ProjectRevisionPostDto ProjectRevisions { get; set; }


        public class SubmitProjectV1CommandHandler : IRequestHandler<SubmitProjectCommand, CustomResponse<bool>>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IProjectDService _projectService;
            private readonly ILoggedInUserService _loggedInUserService;
            private readonly IHostingEnvironment _env;
            private readonly IMapper _mapper;
            private readonly IProjectNotificationService _projectNotificationService;
            private readonly IProjectAuditLogService _auditLogService;

            public SubmitProjectV1CommandHandler(
                IUnitOfWork unitOfWork,
                IMapper mapper,
                IProjectDService projectService,
                ILoggedInUserService loggedInUserService,
                IHostingEnvironment env,
                IProjectNotificationService projectNotificationService,
                IProjectAuditLogService auditLogService
            )
            {
                _unitOfWork = unitOfWork;
                _projectService = projectService;
                _loggedInUserService = loggedInUserService;
                _env = env;
                _mapper = mapper;
                _projectNotificationService = projectNotificationService;
                _auditLogService = auditLogService;
            }
            public async Task<CustomResponse<bool>> Handle(SubmitProjectCommand request, CancellationToken cancellationToken)
            {
                CustomResponse<bool> response = new CustomResponse<bool>();
                Guid? revisionId = request.RevisionId;
                int oldStatus = (int)RevisionStatus.Draft;
                if (revisionId != null)
                {
                    var projectInvision = await _unitOfWork.RevisionRepository.GetSingleAsync(x => x.Id == revisionId,
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

                    oldStatus = projectInvision.RevisionStatus;

                    if (await _projectService.IsProjectNameExist(request.ProjectInfo.Name, projectInvision.Project.Id))
                    {
                        response.Errors.Add(ExceptionMessages.ProjectNameAlreadyInUse);
                        return response;
                    }

                    // check permission
                    if (!(await _projectService.CheckPermissionUserTrigger(projectInvision, ProjectTrigger.Submit)))
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

                    var projectRevision = await _projectService.UpdateProjectInforAsync(projectInvision, request.ProjectInfo, ProjectTrigger.Submit);
                    if (projectRevision == null)
                    {
                        response.Data = false;
                        response.IsSucceed = false;
                        return response;
                    }

                    await _projectService.UpdateProjectEnviromentAsync(projectInvision, request.Environmental);
                    await _projectService.UpdateProjectInfrastructureAsync(projectInvision, request.Infrastructure);

                    await _unitOfWork.CommitAsync();
                    _unitOfWork.DetachEntity<Project>(projectInvision.Project);

                    await _projectService.UpdateProjectEntity(projectInvision);
                    await _unitOfWork.CommitAsync();
                }
                else
                {
                    if (await _projectService.IsProjectNameExist(request.ProjectInfo.Name))
                    {
                        response.Errors.Add(ExceptionMessages.ProjectNameAlreadyInUse);
                        return response;
                    }

                    var projectRevision = await _projectService.UpdateProjectInforAsync(null, request.ProjectInfo, ProjectTrigger.Submit);
                    if (projectRevision == null)
                    {
                        response.Data = false;
                        response.IsSucceed = false;
                        return response;
                    }

                    await _projectService.UpdateProjectEnviromentAsync(projectRevision, request.Environmental);
                    await _projectService.UpdateProjectInfrastructureAsync(projectRevision, request.Infrastructure);

                    await _unitOfWork.CommitAsync();
                    revisionId = projectRevision.Id;
                    _unitOfWork.DetachEntity<Project>(projectRevision.Project);
                    await _projectService.UpdateProjectEntity(projectRevision);

                    await _unitOfWork.CommitAsync();
                }

                await _auditLogService.AddLogProjectAsync(revisionId.Value, (oldStatus == (int)RevisionStatus.ReSubmitted || oldStatus == (int)RevisionStatus.Returned) ? AuditLogStatus.ReSubmitted : AuditLogStatus.Submitted);
                await _unitOfWork.CommitAsync();

                await _projectNotificationService.CoeSubmitProjectAsync(revisionId.Value);
                await _unitOfWork.CommitAsync();

                response.Data = true;
                response.IsSucceed = true;
                return response;

            }


        }
    }
}
