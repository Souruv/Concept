using CF.AuthService.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace CF.AuthService.Application.Features.UserFeatures.Commands
{
    public class UpdateUserRoleCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public Guid RoleId { get; set; }
        public class UpdateUserRoleCommanddHandler : IRequestHandler<UpdateUserRoleCommand, bool>
        {
            private readonly IUnitOfWork _unitOfWork;
            public UpdateUserRoleCommanddHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
            public async Task<bool> Handle(UpdateUserRoleCommand command, CancellationToken cancellationToken)
            {
                var user = await _unitOfWork.UserRepository.GetSingleAsync(a => a.Id == command.Id);

                if (user == null)
                {
                    return default;
                }
                else
                {
                    user.RoleId = command.RoleId;
                    
                    _unitOfWork.UserRepository.Update(user);
                    await _unitOfWork.CommitAsync();
                    return true;
                }
            }
        }
    }
}
