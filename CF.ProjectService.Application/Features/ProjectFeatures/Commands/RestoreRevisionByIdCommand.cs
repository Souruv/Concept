using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CF.ProjectService.Application.Common.Interfaces;
using CF.ProjectService.Application.Services.Interfaces;
using CF.ProjectService.Application.Entities;
using CF.ProjectService.Application.Common.Enums;

namespace CF.ProjectService.Application.Features.ProjectFeatures.Commands
{
    public class RestoreRevisionByIdCommand : IRequest<bool>
    {
        public Guid RevisionId { get; set; }
        public class RestoreRevisionByIdCommandHandler : IRequestHandler<RestoreRevisionByIdCommand, bool>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IProjectDService _projectService;
            public RestoreRevisionByIdCommandHandler(IUnitOfWork unitOfWork, IProjectDService projectService)
            {
                _unitOfWork = unitOfWork;
                _projectService = projectService;
            }
            public async Task<bool> Handle(RestoreRevisionByIdCommand command, CancellationToken cancellationToken)
            {
                //var project = await _unitOfWork.ProjectRepository.GetSingleAsync(a => a.Id == command.ProjectId);

                var revision = await _unitOfWork.RevisionRepository.Filter(x => x.Id == command.RevisionId,
                    source => source.Include(x => x.Project)).FirstOrDefaultAsync();

                if (revision == null) return default;
                revision.IsDeleted = false;
                revision.RevisionStatus = (int)RevisionStatus.Draft;
                revision.RevisionNo = await _projectService.GetNextRevisionNo(revision.ProjectId);
                if (revision.Project.IsDeleted)
                {
                    revision.Project.IsDeleted = false;

                }
                var project = revision.Project;
                project.IsDeleted = false;
                _unitOfWork.RevisionRepository.Update(revision);
                _unitOfWork.ProjectRepository.Update(project);


                await _unitOfWork.CommitAsync();
                return true;
            }
        }
    }
}
