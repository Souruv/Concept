using CF.ProjectService.Application.Common.Interfaces;
using CF.ProjectService.Application.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CF.ProjectService.Application.Features.UserFeatures.Commands
{
    public class CreateUserCommand : IRequest<int>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string UserPrincipal { get; set; }
        public string DepartmentName { get; set; }
        public int Role { get; set; }

        public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
        {
            private readonly IUnitOfWork _unitOfWork;
            public CreateUserCommandHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
            public async Task<int> Handle(CreateUserCommand command, CancellationToken cancellationToken)
            {
                var user = new AppUser();
                user.Id = Guid.NewGuid();
                user.Name = command.Name;
                user.Email = command.Email;
                user.DepartmentName = command.DepartmentName;
                user.UserPrincipal = user.Email;
                user.Role = 2;//command.Role;
                _unitOfWork.UserRepository.Insert(user);
                await _unitOfWork.CommitAsync();
                return 1;
            }
        }
    }
}
