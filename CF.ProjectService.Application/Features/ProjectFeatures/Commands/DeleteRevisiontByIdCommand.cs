using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CF.ProjectService.Application.Common.Interfaces;

namespace CF.ProjectService.Application.Features.ProjectFeatures.Commands
{
    public class DeleteRevisiontByIdCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public class DeleteRevisiontByIdCommandHandler : IRequestHandler<DeleteRevisiontByIdCommand, bool>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly ILoggedInUserService _loggedInUserService;
            public DeleteRevisiontByIdCommandHandler(IUnitOfWork unitOfWork, ILoggedInUserService loggedInUserService)
            {
                _unitOfWork = unitOfWork;
                _loggedInUserService = loggedInUserService;
            }
            public async Task<bool> Handle(DeleteRevisiontByIdCommand command, CancellationToken cancellationToken)
            {
                var revision = await _unitOfWork.RevisionRepository.GetSingleAsync(a => a.Id == command.Id);
                if (revision == null) return default;
                revision.IsDeleted = true;
                revision.DeletedOn = DateTime.Now;
                revision.DeletedByUserId = _loggedInUserService.Id;
                _unitOfWork.RevisionRepository.Update(revision);

                await _unitOfWork.CommitAsync();
                return true;
            }
        }
    }
}
