
using CF.ProjectService.Application.Common.Interfaces;
using CF.ProjectService.Application.Entities;
using CF.ProjectService.Application.Features.ProjectFeatures.Dto;
using CF.ProjectService.Application.Features.UserFeatures.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CF.ProjectService.Application.Features.ProjectFeatures.Commands
{
    public class UpdateProjectCommand : IRequest<int>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }



        public ProjectRevisionPostDto ProjectRevisions { get; set; }

        public class UpdateProjectCommandHandle : IRequestHandler<UpdateProjectCommand, int>
        {
            private readonly IUnitOfWork _unitOfWork;
            public UpdateProjectCommandHandle(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
            public async Task<int> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
            {
                // update project
                var project = await _unitOfWork.ProjectRepository.GetSingleAsync(x => x.Id == request.Id);
                project.Name = request.Name;
               
                _unitOfWork.ProjectRepository.Update(project);

                // update project revision

                var projectInvision = await _unitOfWork.RevisionRepository.GetSingleAsync(x => x.Id == request.ProjectRevisions.Id);
                projectInvision.ProjectStageId = request.ProjectRevisions.ProjectStageId;

                _unitOfWork.RevisionRepository.Update(projectInvision);

                // update share with
               

                await _unitOfWork.CommitAsync();

                return 1;
            }
        }
    }
}
