using CF.ProjectService.Application.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CF.ProjectService.Application.Common.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using CF.ProjectService.Application.Features.UserFeatures.Dto;
using System.Linq;
using CF.ProjectService.Application.Common.Mappings;
using CF.ProjectService.Application.Common.Enums;
using AutoMapper.Configuration.Annotations;
using CF.ProjectService.Application.Common.Exceptions;
using CF.ProjectService.Application.Services.Interfaces;

namespace CF.ProjectService.Application.Features.ProjectFeatures.Commands
{
    public class CopyProjectCommand : IRequest<bool>
    {
        public Guid ProjectId { get; set; }

        public class CopyProjectCommandHandler : IRequestHandler<CopyProjectCommand, bool>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IProjectDService _projectService;
            public CopyProjectCommandHandler(IUnitOfWork unitOfWork, IProjectDService projectService)
            {
                _unitOfWork = unitOfWork;
                _projectService = projectService;
            }
            public async Task<bool> Handle(CopyProjectCommand command, CancellationToken cancellationToken)
            {
                var existingProject = await _unitOfWork.RevisionRepository.Filter(r => r.Id == command.ProjectId,
                    source => source.Include(x => x.Project)).FirstOrDefaultAsync();

                if (existingProject == null)
                {
                    throw new NotFoundException("Project not found");
                }

                var newProject = new Project()
                {
                    Id = Guid.NewGuid(),
                    //newProject.Name = await _unitOfWork.ProjectRepository.GetUniqueFileName(existingProject.Name);// + " - Copy";
                    //SpecialistUserId = existingProject.Project.SpecialistUserId,
                    //TechicalManagerId = existingProject.Project.TechicalManagerId,
                    //SpecialistsAlternateUserId = existingProject.Project.SpecialistsAlternateUserId,
                    LastCreatedOn = existingProject.Project.LastCreatedOn,
                    LastModifiedOn = existingProject.Project.LastModifiedOn,
                    LastRevisionNo = existingProject.Project.LastRevisionNo,
                    LastSubmittedOn = existingProject.Project.LastSubmittedOn,
                    Name = await _projectService.GetNextUniqueProjectName(existingProject.Project.Name)
                };
                //_unitOfWork.ProjectRepository.Insert(newProject);


                //copy revision
                //var newRevisoin = await _unitOfWork.RevisionRepository.GetSingleAsync(x => x.Id == command.ProjectId);
                var newRevisoin = new ProjectRevision() {
                    Id = Guid.NewGuid(),
                    RevisionStatus = (int)RevisionStatus.Draft,
                    RevisionNo = 1,
                    ProjectId = newProject.Id,
                    ProjectStageId = existingProject.ProjectStageId
                };

                //_unitOfWork.RevisionRepository.Insert(newRevisoin);

                newProject.ProjectRevisions.Add(newRevisoin);
                ////_unitOfWork.RevisionRepository.Insert(newRevisoin);
                _unitOfWork.ProjectRepository.Insert(newProject);

                
                //copy sharewith
               

                await _unitOfWork.CommitAsync();
                return true;
            }
        }
    }
}
