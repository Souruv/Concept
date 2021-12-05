using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using CF.AuthService.Application.Common.Interfaces;

namespace CF.ProjectService.Application.Features.UserFeatures.Commands
{
    public class DeleteUserByIdCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public class DeleteUserByIdCommandHandler : IRequestHandler<DeleteUserByIdCommand, bool>
        {
            private readonly IUnitOfWork _unitOfWork;
            public DeleteUserByIdCommandHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
            public async Task<bool> Handle(DeleteUserByIdCommand command, CancellationToken cancellationToken)
            {
                var user = await _unitOfWork.UserRepository.GetSingleAsync(a => a.Id == command.Id);
                if (user == null) return default;
                user.IsDeleted = true;
                user.DeletedOn = DateTime.Now;
                _unitOfWork.UserRepository.Update(user);
                await _unitOfWork.CommitAsync();
                return true;
            }
        }
    }
}
