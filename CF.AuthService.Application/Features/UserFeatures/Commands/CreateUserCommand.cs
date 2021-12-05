
using CF.AuthService.Application.Common.Exceptions;
using CF.AuthService.Application.Common.Interfaces;
using CF.AuthService.Application.Entities;
using CF.AuthService.Application.Services.ServiceBus;
using MediatR;
using Microsoft.Azure.ServiceBus;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CF.AuthService.Application.Features.UserFeatures.Commands
{
    public class CreateUserCommand : IRequest<CustomResponse<bool>>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string UserPrincipal { get; set; }
        public string DepartmentName { get; set; }
        public Guid RoleId { get; set; }
        public Guid? FelStageid { get; set; }
        public bool IsAdmin { get; set; }
        public string Area { get; set; }
        public bool HaveDuplicate { get; set; }
        public Guid? UserIdToRemove { get; set; }
        public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, CustomResponse<bool>>
        {
            private readonly IUnitOfWork _unitOfWork;

            private readonly ISenderService _senderService;
            private readonly string topicName = "UserAddedTopic";


            public CreateUserCommandHandler(IUnitOfWork unitOfWork, ISenderService senderService)
            {
                _unitOfWork = unitOfWork;
                _senderService = senderService;

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
                user.DepartmentName = command.DepartmentName;
                user.UserPrincipal = user.Email;
               // user.Role = 2;
                user.RoleId = command.RoleId;
                user.FelStageId = command.FelStageid;
                user.IsAdmin = command.IsAdmin;
                user.Area = command.Area;
               // _unitOfWork.UserRepository.Insert(user);

                if (command.HaveDuplicate)
                {
                    var userToRemove = await _unitOfWork.UserRepository.GetSingleAsync(a => a.Id == command.UserIdToRemove);
                    userToRemove.IsDeleted = true;
                    userToRemove.DeletedOn = DateTime.Now;
                    _unitOfWork.UserRepository.Update(userToRemove);
                }

                // await _unitOfWork.CommitAsync();

                //Send To Service Bus//
                UserServiceBus userServiceBus = new UserServiceBus
                    {
                    Id = user.Id,
                    Name = user.Name,
                    Email = user.Email,
                    Role = 2,
                    DepartmentName = user.DepartmentName,
                    UserPrincipal = user.UserPrincipal,
                    IsDeleted = false,
                    CreatedOn = System.DateTime.Today,
                    CreatedByUserId= new Guid("AD7230BA-0BA1-4E09-8FF7-54F2ECA57BA6")
                };

                await _senderService.SendMessageAsync(userServiceBus, topicName);

                response.Data = true;
                response.IsSucceed = true;
                return response;
            }
        }
    }
}
