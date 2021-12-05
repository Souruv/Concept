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
    public class DeleteProjectByIdCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public class DeleteProjectByIdCommandHandler : IRequestHandler<DeleteProjectByIdCommand, bool>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly ILoggedInUserService _loggedInUserService;
            public DeleteProjectByIdCommandHandler(IUnitOfWork unitOfWork,ILoggedInUserService loggedInUserService)
            {
                _unitOfWork = unitOfWork;
                _loggedInUserService = loggedInUserService;
            }
            public async Task<bool> Handle(DeleteProjectByIdCommand command, CancellationToken cancellationToken)
            {
                var project = await _unitOfWork.ProjectRepository.GetSingleAsync(a => a.Id == command.Id);
                if (project == null) return default;
                project.IsDeleted = true;
                project.DeletedOn = DateTime.Now;
                project.DeletedByUserId = _loggedInUserService.Id;
                _unitOfWork.ProjectRepository.Update(project);
                await _unitOfWork.CommitAsync();
                return true;
            }
        }
    }
}
