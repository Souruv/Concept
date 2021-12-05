using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CF.ProjectService.Application.Common.Interfaces;

namespace CF.ProjectService.Application.Features.UserFeatures.Commands
{
    public class UpdateUserCommand : IRequest<int>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, int>
        {
            private readonly IUnitOfWork _unitOfWork;
            public UpdateUserCommandHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
            public async Task<int> Handle(UpdateUserCommand command, CancellationToken cancellationToken)
            {
                var user = await _unitOfWork.UserRepository.GetSingleAsync(a => a.Id == command.Id);

                if (user == null)
                {
                    return default;
                }
                else
                {
                    user.Email = command.Email;
                    user.Name = command.Name;
                    _unitOfWork.UserRepository.Update(user);
                    await _unitOfWork.CommitAsync();
                    return 0;
                }
            }
        }
    }
}
