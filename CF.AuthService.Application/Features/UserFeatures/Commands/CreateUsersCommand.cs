
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CF.AuthService.Application.Features.UserFeatures.Dto;
using CF.AuthService.Application.Entities;
using CF.AuthService.Application.Common.Interfaces;
using CF.AuthService.Application.Services.ServiceBus;

namespace CF.AuthService.Application.Features.UserFeatures.Commands
{
    public class CreateUsersCommand : IRequest<ICollection<CreateUsersResponseDto>>
    {
        public ICollection<AppUserDto> Users { get; set; } 
        //public string Name { get; set; }
        //public string Email { get; set; }
        //public string UserPrincipal { get; set; }
        //public string DepartmentName { get; set; }
        //public int Role { get; set; }

        public class CreateUserCommandHandler : IRequestHandler<CreateUsersCommand, ICollection<CreateUsersResponseDto>>
        {
            private readonly IUnitOfWork _unitOfWork;

            public CreateUserCommandHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
               
            }
            public async Task<ICollection<CreateUsersResponseDto>> Handle(CreateUsersCommand command, CancellationToken cancellationToken)
            {
                
            ICollection<CreateUsersResponseDto> responseDtos = new List<CreateUsersResponseDto>();
                foreach (var user in command.Users)
                {
                    var foundUser = await _unitOfWork.UserRepository.Filter(a => !a.IsDeleted && a.Email == user.Email).FirstOrDefaultAsync();//.ProjectTo<UserDto>(_mapper.ConfigurationProvider).FirstOrDefault();
                    if (foundUser == null)
                    {
                        var appuser = new AppUser();
                        appuser.Id = Guid.NewGuid();
                        appuser.Name = user.Name;
                        appuser.Email = user.Email;
                        appuser.DepartmentName = user.DepartmentName;
                        appuser.UserPrincipal = user.Email;
                        appuser.RoleId = user.RoleId;
                        _unitOfWork.UserRepository.Insert(appuser);


                       


                        responseDtos.Add(new CreateUsersResponseDto()
                        {
                            Id = appuser.Id,
                            Name = appuser.Name,
                            Email = appuser.Email,
                            IsExist = false
                        });
                    }
                    else
                    {
                        responseDtos.Add(new CreateUsersResponseDto()
                        {
                            Id = foundUser.Id,
                            Name = foundUser.Name,
                            Email = foundUser.Email,
                            IsExist = true
                        });
                    }

                }
                
                await _unitOfWork.CommitAsync();

               
                return responseDtos;
            }
        }
    }
}
