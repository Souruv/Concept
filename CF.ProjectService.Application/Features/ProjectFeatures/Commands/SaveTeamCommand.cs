using CF.ProjectService.Application.Common.Enums;
using CF.ProjectService.Application.Common.Exceptions;
using CF.ProjectService.Application.Common.Interfaces;
using CF.ProjectService.Application.Common.Response;
using CF.ProjectService.Application.Entities;
using CF.ProjectService.Application.Features.ProjectFeatures.Dto;
using CF.ProjectService.Application.Features.UserFeatures.Dto;
using CF.ProjectService.Application.Services.Interfaces;
using CF.ProjectService.Application.Services.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CF.ProjectService.Application.Features.ProjectFeatures.Commands
{
    public class SaveTeamMemberCommand : IRequest<CustomResponse<Guid>>
    {
        public bool? IsAcknowledged { get; set; }
        public Guid RevisionId { get; set; }
        public Guid? FrontEndEngineerTechnical { get; set; }
        public AppUserDto[]? FrontEndEngineers { get; set; }
        public Guid? CostEngineerTechnical { get; set; }
        public AppUserDto[]? CostEngineers { get; set; }
        public AppUserDto[]? Admins { get; set; }


        public class SaveTeamMemberCommandHandler : IRequestHandler<SaveTeamMemberCommand, CustomResponse<Guid>>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IProjectDService _projectService;
            private readonly IHostingEnvironment _env;
            public SaveTeamMemberCommandHandler(IUnitOfWork unitOfWork, IProjectDService projectService, IHostingEnvironment env)
            {
                _unitOfWork = unitOfWork;
                _projectService = projectService;
                _env = env;
            }
            public async Task<CustomResponse<Guid>> Handle(SaveTeamMemberCommand request, CancellationToken cancellationToken)
            {

                CustomResponse<Guid> response = new CustomResponse<Guid>();

                var projectRevision = await _unitOfWork.RevisionRepository.GetSingleAsync(x => x.Id == request.RevisionId
                , source => source.Include(x => x.Project)
                .ThenInclude(x => x.ProjectUsers.Where(y => !y.IsDeleted))

                );

                //var project = await _unitOfWork.ProjectRepository.GetSingleAsync(x => x.Id == projectRevision.ProjectId ,
                //       source => source.Include(x => x.ProjectUsers.Where(y => !y.IsDeleted)));



                var existingFetm = projectRevision.Project.ProjectUsers.Where(x => x.Type == (int)ProjectUserType.FETechnicalProfessional).FirstOrDefault();

                if (request.FrontEndEngineerTechnical != null)
                {
                    var newFetmId = request.FrontEndEngineerTechnical;
                   

                    if (existingFetm == null)
                    {
                        var projectUser = new ProjectUser()
                        {
                            Id = Guid.NewGuid(),
                            ProjectId = projectRevision.Project.Id,
                            UserId = (Guid)request.FrontEndEngineerTechnical,
                            Type = (int)ProjectUserType.FETechnicalProfessional
                        };

                        _unitOfWork.ProjectUserRepository.Insert(projectUser);
                    }
                    else if (newFetmId != existingFetm.UserId)
                    {
                        existingFetm.UserId = (Guid)request.FrontEndEngineerTechnical;
                        _unitOfWork.ProjectUserRepository.Update(existingFetm);
                    }

                }
                else
                {
                    if (existingFetm != null)
                    {
                        existingFetm.IsDeleted = true;
                        _unitOfWork.ProjectUserRepository.Update(existingFetm);
                    }
                }



                if (request.FrontEndEngineers != null && request.FrontEndEngineers.Count() > 0)
                {
                    var newFeEngIds = request.FrontEndEngineers.Select(x => x.Id).ToList();
                    var existingFeEngIds = projectRevision.Project.ProjectUsers.Where(x => x.Type == (int)ProjectUserType.FEEngineer)
                        .Select(x => x.UserId).ToList();

                    var tobeinsertedFeEngList = request.FrontEndEngineers.Where(x => !existingFeEngIds.Contains(x.Id));

                    var tobeDeletedFeEngList = projectRevision.Project.ProjectUsers.Where(x => x.Type == (int)ProjectUserType.FEEngineer
                     && !newFeEngIds.Contains(x.UserId));

                    foreach (var user in tobeinsertedFeEngList)
                    {
                        var projectUser = new ProjectUser()
                        {
                            Id = Guid.NewGuid(),
                            ProjectId = projectRevision.Project.Id,
                            UserId = user.Id,
                            Type = (int)ProjectUserType.FEEngineer

                        };

                        _unitOfWork.ProjectUserRepository.Insert(projectUser);
                    }
                    foreach (var teamMember in tobeDeletedFeEngList)
                    {
                        teamMember.IsDeleted = true;
                        _unitOfWork.ProjectUserRepository.Update(teamMember);
                    }
                }
                else
                {
                    var tobeDeletedFeEngList = projectRevision.Project.ProjectUsers.Where(x => x.Type == (int)ProjectUserType.FEEngineer);

                    foreach (var teamMember in tobeDeletedFeEngList)
                    {
                        teamMember.IsDeleted = true;
                        _unitOfWork.ProjectUserRepository.Update(teamMember);
                    }
                }




                var existingCetm = projectRevision.Project.ProjectUsers.Where(x => x.Type == (int)ProjectUserType.CETechnicalProfessional).FirstOrDefault();

                if (request.CostEngineerTechnical != null)
                {
                    var newCetmId = request.CostEngineerTechnical;


                    if (existingCetm == null)
                    {
                        var projectUser = new ProjectUser()
                        {
                            Id = Guid.NewGuid(),
                            ProjectId = projectRevision.Project.Id,
                            UserId = (Guid)request.CostEngineerTechnical,
                            Type = (int)ProjectUserType.CETechnicalProfessional
                        };

                        _unitOfWork.ProjectUserRepository.Insert(projectUser);
                    }
                    else if (newCetmId != existingCetm.UserId)
                    {
                        existingCetm.UserId = (Guid)request.CostEngineerTechnical;
                        _unitOfWork.ProjectUserRepository.Update(existingCetm);
                    }

                }
                else
                {
                    if (existingCetm != null)
                    {
                        existingCetm.IsDeleted = true;
                        _unitOfWork.ProjectUserRepository.Update(existingCetm);
                    }
                }


               

                if (request.CostEngineers != null && request.CostEngineers.Count() > 0)
                {
                    var newCeEngIds = request.CostEngineers.Select(x => x.Id).ToList();
                    var existingCeEngIds = projectRevision.Project.ProjectUsers.Where(x => x.Type == (int)ProjectUserType.CEEngineer)
                        .Select(x => x.UserId).ToList();

                    var tobeinsertedCeEngList = request.CostEngineers.Where(x => !existingCeEngIds.Contains(x.Id));

                    var tobeDeletedCeEngList = projectRevision.Project.ProjectUsers.Where(x => x.Type == (int)ProjectUserType.CEEngineer
                     && !newCeEngIds.Contains(x.UserId));

                    foreach (var user in tobeinsertedCeEngList)
                    {
                        var projectUser = new ProjectUser()
                        {
                            Id = Guid.NewGuid(),
                            ProjectId = projectRevision.Project.Id,
                            UserId = user.Id,
                            Type = (int)ProjectUserType.CEEngineer

                        };

                        _unitOfWork.ProjectUserRepository.Insert(projectUser);
                    }
                    foreach (var teamMember in tobeDeletedCeEngList)
                    {
                        teamMember.IsDeleted = true;
                        _unitOfWork.ProjectUserRepository.Update(teamMember);
                    }
                }
                else
                {
                    var tobeDeletedCeEngList = projectRevision.Project.ProjectUsers.Where(x => x.Type == (int)ProjectUserType.CEEngineer);

                    foreach (var teamMember in tobeDeletedCeEngList)
                    {
                        teamMember.IsDeleted = true;
                        _unitOfWork.ProjectUserRepository.Update(teamMember);
                    }
                }



                if (request.Admins != null && request.Admins.Count() > 0)
                {
                    var newAdminIds = request.Admins.Select(x => x.Id).ToList();
                    var existingAdminIds = projectRevision.Project.ProjectUsers.Where(x => x.Type == (int)ProjectUserType.Admin)
                        .Select(x => x.UserId).ToList();

                    var tobeinsertedAdminList = request.Admins.Where(x => !existingAdminIds.Contains(x.Id));

                    var tobeDeletedAdminList = projectRevision.Project.ProjectUsers.Where(x => x.Type == (int)ProjectUserType.Admin
                     && !newAdminIds.Contains(x.UserId));

                    foreach (var user in tobeinsertedAdminList)
                    {
                        var projectUser = new ProjectUser()
                        {
                            Id = Guid.NewGuid(),
                            ProjectId = projectRevision.Project.Id,
                            UserId = user.Id,
                            Type = (int)ProjectUserType.Admin

                        };

                        _unitOfWork.ProjectUserRepository.Insert(projectUser);
                    }

                    foreach (var teamMember in tobeDeletedAdminList)
                    {
                        teamMember.IsDeleted = true;
                        _unitOfWork.ProjectUserRepository.Update(teamMember);
                    }

                }
                else
                {
                    var tobeDeletedAdminList = projectRevision.Project.ProjectUsers.Where(x => x.Type == (int)ProjectUserType.Admin);
                    foreach (var teamMember in tobeDeletedAdminList)
                    {
                        teamMember.IsDeleted = true;
                        _unitOfWork.ProjectUserRepository.Update(teamMember);
                    }
                }

                //_unitOfWork.RevisionRepository.Update(projectRevision);

                //_unitOfWork.ProjectRepository.Update(projectRevision.Project);

                projectRevision.IsAcknowledged = request.IsAcknowledged.GetValueOrDefault(false);
                _unitOfWork.RevisionRepository.Update(projectRevision);



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
