using CF.ProjectService.Application.Common.Enums;
using CF.ProjectService.Application.Common.Interfaces;
using CF.ProjectService.Application.Entities;
using CF.ProjectService.Application.Features.ProjectFeatures.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CF.ProjectService.Application.Features.ProjectFeatures.Commands
{
    public class SaveProjectAsNewRevisionCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
      
        public ProjectRevisionPostDto ProjectRevisions { get; set; }


        public class SaveProjectAsNewRevisionCommandHandle : IRequestHandler<SaveProjectAsNewRevisionCommand, Guid>
        {
            private readonly IUnitOfWork _unitOfWork;
            public SaveProjectAsNewRevisionCommandHandle(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
            public async Task<Guid> Handle(SaveProjectAsNewRevisionCommand request, CancellationToken cancellationToken)
            {
                // update project
                var project = await _unitOfWork.ProjectRepository.GetSingleAsync(x => x.Id == request.Id);
                project.Name = request.Name;
              

                _unitOfWork.ProjectRepository.Update(project);

                // update project revision

                var revisionLatest = await _unitOfWork.RevisionRepository.GetMaxRevisionNo(request.Id);
                var projectInvision = await _unitOfWork.RevisionRepository.GetSingleAsync(x => x.Id == request.ProjectRevisions.Id);
                projectInvision.Id = Guid.NewGuid();
                projectInvision.RevisionNo = (int)revisionLatest + 1;
                projectInvision.ProjectStageId = request.ProjectRevisions.ProjectStageId;
                projectInvision.RevisionStatus = (int)RevisionStatus.Draft;

                _unitOfWork.RevisionRepository.Insert(projectInvision);

                           

             

                await _unitOfWork.CommitAsync();

                return projectInvision.Id;
            }
        }
    }
}
