using CF.CostBrainService.Application.Common.Exceptions;
using CF.CostBrainService.Application.Common.Interfaces;
using CF.CostBrainService.Application.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CF.CostBrainService.Application.Features.UserFeatures.Commands
{
   public class CreateUserCommand: IRequest<CustomResponse<bool>>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string UserPrincipal { get; set; }
        public string DepartmentName { get; set; }
        public Guid RoleId { get; set; }

        public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, CustomResponse<bool>>
        {
            private readonly IUnitOfWork _unitOfWork;


            public CreateUserCommandHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;

            }
            public async Task<CustomResponse<bool>> Handle(CreateUserCommand command, CancellationToken cancellationToken)
            {
                CustomResponse<bool> response = new CustomResponse<bool>();
                //check if user exists
                var userInfo = await _unitOfWork.UserRepository.GetSingleAsync(a => !a.IsDeleted && a.Email == command.Email);
                if (userInfo != null)
                {
                    response.Data = false;
                    response.IsSucceed = false;
                    response.Errors.Add(ExceptionMessages.UserAlreadyExists);
                    return response;
                }

                var user = new AppUser();
                user.Id = Guid.NewGuid();
                user.Name = command.Name;
                user.Email = command.Email;
                user.Role = 2;
                user.DepartmentName = command.DepartmentName;
                user.UserPrincipal = user.Email;
                user.IsDeleted = user.IsDeleted;
                user.CreatedByUserId = user.CreatedByUserId;
                user.CreatedOn = user.CreatedOn;

                _unitOfWork.UserRepository.Insert(user);

                await _unitOfWork.CommitAsync();



                response.Data = true;
                response.IsSucceed = true;
                return response;
            }
        }
    }
}
