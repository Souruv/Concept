using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CF.ProjectService.Application.Common.Enums;
using CF.ProjectService.Application.Common.Interfaces;
using CF.ProjectService.Application.Entities;
using CF.ProjectService.Application.Services.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using DateTime = System.DateTime;

namespace CF.ProjectService.Application.Features.ProjectFeatures.Commands
{
    public class RejectProjectCommand : IRequest<bool>
    {
        public Guid RevisionId { get; set; }
        public string Remark { get; set; }

        public class RejectProjectCommandHandler : IRequestHandler<RejectProjectCommand, bool>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly ILoggedInUserService _loggedInUserService;

            private readonly IProjectDService _projectService;
            public RejectProjectCommandHandler(IUnitOfWork unitOfWork, ILoggedInUserService loggedInUserService, IProjectDService projectService)
            {
                _unitOfWork = unitOfWork;
                _loggedInUserService = loggedInUserService;
                _projectService = projectService;

            }
            public async Task<bool> Handle(RejectProjectCommand request, CancellationToken cancellationToken)
            {

                var revision =
                    await _unitOfWork.RevisionRepository.GetSingleAsync(x => x.Id == request.RevisionId, source => source.Include(x => x.Project));

                revision.Reject();
                revision.RespondedRemarks = request.Remark;
                revision.SubmittedByUserId = _loggedInUserService.Id;
                revision.SubmittedOn = DateTime.Now;
                _unitOfWork.RevisionRepository.Update(revision);

                

                await _unitOfWork.CommitAsync();

                await _projectService.UpdateProjectEntity(revision);
                return true;
            }
        }
    }
}
