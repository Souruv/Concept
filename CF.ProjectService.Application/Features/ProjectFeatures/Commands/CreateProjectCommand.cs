using CF.ProjectService.Application.Common.Enums;
using CF.ProjectService.Application.Common.Exceptions;
using CF.ProjectService.Application.Common.Interfaces;
using CF.ProjectService.Application.Common.Response;
using CF.ProjectService.Application.Entities;
using CF.ProjectService.Application.Features.UserFeatures.Dto;
using CF.ProjectService.Application.Services.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CF.ProjectService.Application.Features.ProjectFeatures.Commands
{
    public class CreateProjectCommand : IRequest<CustomResponse<Guid>>
    {
        public string? File { get; set; }
        public string Name { get; set; }
        public string? Business { get; set; }
        public string? Area { get; set; }
        public string? Asset { get; set; }

        public string? Pid { get; set; }
        public string? ProjectType { get; set; }
        public string? Stage { get; set; }
        public IList<Guid> Nature { get; set; }

        public decimal? TargetUnitTechnicalCost { get; set; }
        public string? Utc { get; set; }

        public DateTime? ExpectedRespondDate { get; set; }
        public string? Remarks { get; set; }
        public string? ServiceRequest { get; set; }
        public AppUserDto[]? ProjectManagerList { get; set; }
        public AppUserDto[]? ProductionTechnologistList { get; set; }
        public AppUserDto[]? GeologistList { get; set; }
        public AppUserDto[]? GeoPhysicistList { get; set; }
        public AppUserDto[]? ReservoirEngineerList { get; set; }
        public AppUserDto[]? PetroPhysicistList { get; set; }
        public AppUserDto[]? WellsEngineerList { get; set; }


        //public IList<ProjectUserDto> ProjectUsers { get; set; }
        //public ProjectRevisionPostDto ProjectRevisions { get; set; }
        public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, CustomResponse<Guid>>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IProjectDService _projectService;
            private readonly IHostingEnvironment _env;
            public CreateProjectCommandHandler(IUnitOfWork unitOfWork, IProjectDService projectService, IHostingEnvironment env)
            {
                _unitOfWork = unitOfWork;
                _projectService = projectService;
                _env = env;
            }
            public async Task<CustomResponse<Guid>> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
            {

                CustomResponse<Guid> response = new CustomResponse<Guid>();
                if (await _projectService.IsProjectNameExist(request.Name))
                {
                    response.Errors.Add(ExceptionMessages.ProjectNameAlreadyInUse);

                    return response;

                }

                var newId = Guid.NewGuid();
                var newProject = new Project()
                {
                    Id = newId,
                    Name = request.Name,
                    Pid = await _projectService.GetNextPid(),
                    ProjectType = request.ProjectType,
                    Business = request.Business,
                    Area = request.Area,
                    Asset = request.Asset,

                };

                foreach (var user in request.ProjectManagerList)
                {
                    var projectUser = new ProjectUser()
                    {
                        Id = Guid.NewGuid(),
                        ProjectId = newId,
                        UserId = user.Id,
                        Type = (int)ProjectUserType.SubSurfaceProjectManager,
                        CanEdit =false,

                    };

                    newProject.ProjectUsers.Add(projectUser);
                }
                foreach (var user in request.ProductionTechnologistList)
                {
                    var projectUser = new ProjectUser()
                    {
                        Id = Guid.NewGuid(),
                        ProjectId = newId,
                        UserId = user.Id,
                        Type = (int)ProjectUserType.ProductionTechnologist,
                        CanEdit = false,

                    };

                    newProject.ProjectUsers.Add(projectUser);
                }

                foreach (var user in request.GeologistList)
                {
                    var projectUser = new ProjectUser()
                    {
                        Id = Guid.NewGuid(),
                        ProjectId = newId,
                        UserId = user.Id,
                        Type = (int)ProjectUserType.Geologist,
                        CanEdit = false,

                    };

                    newProject.ProjectUsers.Add(projectUser);
                }

                foreach (var user in request.GeoPhysicistList)
                {
                    var projectUser = new ProjectUser()
                    {
                        Id = Guid.NewGuid(),
                        ProjectId = newId,
                        UserId = user.Id,
                        Type = (int)ProjectUserType.GeoPhysicist,
                        CanEdit = false,

                    };

                    newProject.ProjectUsers.Add(projectUser);
                }


                foreach (var user in request.ReservoirEngineerList)
                {
                    var projectUser = new ProjectUser()
                    {
                        Id = Guid.NewGuid(),
                        ProjectId = newId,
                        UserId = user.Id,
                        Type = (int)ProjectUserType.ReservoirEngineer,
                        CanEdit = false,

                    };

                    newProject.ProjectUsers.Add(projectUser);
                }


                foreach (var user in request.PetroPhysicistList)
                {
                    var projectUser = new ProjectUser()
                    {
                        Id = Guid.NewGuid(),
                        ProjectId = newId,
                        UserId = user.Id,
                        Type = (int)ProjectUserType.PetroPhysicist,
                        CanEdit = false,

                    };

                    newProject.ProjectUsers.Add(projectUser);
                }

                foreach (var user in request.WellsEngineerList)
                {
                    var projectUser = new ProjectUser()
                    {
                        Id = Guid.NewGuid(),
                        ProjectId = newId,
                        UserId = user.Id,
                        Type = (int)ProjectUserType.WellsEngineer,
                        CanEdit = false,

                    };

                    newProject.ProjectUsers.Add(projectUser);
                }


                _unitOfWork.ProjectRepository.Insert(newProject);


                var projectRevision = new ProjectRevision()
                {
                    Id = Guid.NewGuid(),
                    ProjectId = newId,
                    RevisionNo = 1,
                    ProjectStageId = new Guid(request.Stage),
                    RevisionStatus = (int)RevisionStatus.Draft,

                    ExpecedFirstResponseBy = request.ExpectedRespondDate,
                    Remarks = request.Remarks,
                    ServiecRequestNUmber = request.ServiceRequest,
                    TargetUnitTechnicalCost = request.TargetUnitTechnicalCost,
                    UtcCountry = request.Utc
            };

                _unitOfWork.RevisionRepository.Insert(projectRevision);





                foreach (var item in request.Nature)
                {

                    var newProjectNatureDetail = new ProjectNatureDetail()
                    {
                        Id = Guid.NewGuid(),
                        ProjectNatureId = item,
                        ProjectId = newProject.Id

                    };
                    _unitOfWork.ProjectNatureDetailRepository.Insert(newProjectNatureDetail);

                }


                await _unitOfWork.CommitAsync();

                await _projectService.UpdateProjectEntity(projectRevision);

                await _unitOfWork.CommitAsync();


                response.Data = projectRevision.Id;
                response.IsSucceed = true;
                return response;


            }
        }

    }
}
