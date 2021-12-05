using CF.ProjectService.Application.Common.Constants;
using CF.ProjectService.Application.Common.Enums;
using CF.ProjectService.Application.Common.Exceptions;
using CF.ProjectService.Application.Common.Extensions;
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
    public class SaveProjectCommand : IRequest<CustomResponse<bool>>
    {
        // public Guid? Id { get; set; }

        public Guid? RevisionId { get; set; }

        public ProjectInfoPostDto ProjectInfo { get; set; }

        public EnviromentalDto Environmental { get; set; }

        public InfrastructureDto Infrastructure { get; set; }




        //public IList<ProjectUserDto> ProjectUsers { get; set; }
        //public ProjectRevisionPostDto ProjectRevisions { get; set; }


        public class SaveProjectCommandHandler : IRequestHandler<SaveProjectCommand, CustomResponse<bool>>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IProjectDService _projectService;
            private readonly IHostingEnvironment _env;
            private readonly ILoggedInUserService _loggedInUserService;
            private readonly IProjectAuditLogService _auditLogService;

            public SaveProjectCommandHandler(
                IUnitOfWork unitOfWork,
                IProjectDService projectService,
                IHostingEnvironment env,
                ILoggedInUserService loggedInUserService,
                IProjectAuditLogService auditLogService
            )
            {
                _unitOfWork = unitOfWork;
                _projectService = projectService;
                _env = env;
                _loggedInUserService = loggedInUserService;
                _auditLogService = auditLogService;
            }

            public async Task<CustomResponse<bool>> Handle(SaveProjectCommand request, CancellationToken cancellationToken)
            {
                CustomResponse<bool> response = new CustomResponse<bool>();

                if (request.RevisionId != null)
                {
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

                    if (request.ProjectInfo != null)
                    {
                        if (await _projectService.IsProjectNameExist(request.ProjectInfo.Name, projectInvision.Project.Id))
                        {
                            response.Errors.Add(ExceptionMessages.ProjectNameAlreadyInUse);
                            return response;
                        }

                        var projectRevision = await _projectService.UpdateProjectInforAsync(projectInvision, request.ProjectInfo, ProjectTrigger.Draft);
                        if (projectRevision == null)
                        {
                            response.Data = false;
                            response.IsSucceed = false;
                            return response;
                        }
                    }

                    if (request.Environmental != null)
                    {
                        if (!request.Environmental.ValidationSaveChange())
                        {
                            response.Data = false;
                            response.IsSucceed = false;
                            response.Errors.Add(ExceptionMessages.SomeThingWrong);
                            return response;
                        }
                        else if (request.Environmental.CheckChange(projectInvision.Enviromental))
                        {
                            await _projectService.UpdateProjectEnviromentAsync(projectInvision, request.Environmental);
                            if (_loggedInUserService.User.RoleId == RoleId.FEE_TP || _loggedInUserService.User.RoleId == RoleId.FEE)
                            {
                                await _auditLogService.AddLogProjectAsync(projectInvision.Id, AuditLogStatus.UpdatedEnvironmental);
                            }
                        }
                    }

                    if (request.Infrastructure != null)
                    {
                        if (!request.Infrastructure.ValidationSaveChange())
                        {
                            response.Data = false;
                            response.IsSucceed = false;
                            response.Errors.Add(ExceptionMessages.SomeThingWrong);
                            return response;
                        }
                        else if (request.Infrastructure.CheckChange(projectInvision.InfrastructureData))
                        {
                            await _projectService.UpdateProjectInfrastructureAsync(projectInvision, request.Infrastructure);
                            if (_loggedInUserService.User.RoleId == RoleId.FEE_TP || _loggedInUserService.User.RoleId == RoleId.FEE)
                            {
                                await _auditLogService.AddLogProjectAsync(projectInvision.Id, AuditLogStatus.UpdatedInfrastructure);
                            }
                        }
                    }

                    await _unitOfWork.CommitAsync();
                    _unitOfWork.DetachEntity<Project>(projectInvision.Project);

                    await _projectService.UpdateProjectEntity(projectInvision);
                    await _unitOfWork.CommitAsync();

                }
                else
                {
                    if (request.ProjectInfo != null && await _projectService.IsProjectNameExist(request.ProjectInfo.Name))
                    {
                        response.Errors.Add(ExceptionMessages.ProjectNameAlreadyInUse);
                        return response;
                    }

                    var projectRevision = await _projectService.UpdateProjectInforAsync(null, request.ProjectInfo, ProjectTrigger.Draft);
                    if (projectRevision == null)
                    {
                        response.Data = false;
                        response.IsSucceed = false;
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

                    await _projectService.UpdateProjectEnviromentAsync(projectRevision, request.Environmental);
                    await _projectService.UpdateProjectInfrastructureAsync(projectRevision, request.Infrastructure);

                    await _unitOfWork.CommitAsync();
                    _unitOfWork.DetachEntity<Project>(projectRevision.Project);
                    await _projectService.UpdateProjectEntity(projectRevision);

                    await _unitOfWork.CommitAsync();
                }

                response.Data = true;
                response.IsSucceed = true;
                return response;

            }
        }
    }
}
