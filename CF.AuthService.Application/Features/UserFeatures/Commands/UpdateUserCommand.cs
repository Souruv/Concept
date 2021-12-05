using AutoMapper;
using CF.AuthService.Application.Common.Exceptions;
using CF.AuthService.Application.Common.Interfaces;
using CF.AuthService.Application.Features.UserFeatures.Dto;
using CF.AuthService.Application.Services.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace CF.AuthService.Application.Features.UserFeatures.Commands
{
    public class UpdateUserCommand : IRequest<CustomResponse<AppUserDto>>
    {
        public Guid Id { get; set; }
        public Guid RoleId { get; set; }
        public Guid? FelStageid { get; set; }
        public string Area { get; set; }
        public bool? IsAdmin { get; set; }
        public bool HaveDuplicate { get; set; }
        public Guid? UserIdToRemove { get; set; }

        //public UpdateUserDto User { get; set; }

        public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, CustomResponse<AppUserDto>>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IUserService _userService;
            private readonly IMapper _mapper;
            public UpdateUserCommandHandler(IUnitOfWork unitOfWork, IUserService userService, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _userService = userService;
                _mapper = mapper;
            }
            public async Task<CustomResponse<AppUserDto>> Handle(UpdateUserCommand command, CancellationToken cancellationToken)
            {
                CustomResponse<AppUserDto> response = new CustomResponse<AppUserDto>();

                //var existedUser = await _userService.CheckDuplicateUser(command.User);
                //if (existedUser != null)
                //{
                //    response.Data = _mapper.Map<AppUserDto>(existedUser);
                //    response.IsSucceed = false;
                //    response.Message = "Existed user";
                //    response.Errors.Add(ExceptionMessages.ExistedUser);
                //    return response;
                //}

                var userFromDb = await _unitOfWork.UserRepository.GetSingleAsync(a => a.Id == command.Id);
                if (userFromDb == null)
                {
                    response.Data = null;
                    response.IsSucceed = false;
                    response.Errors.Add(ExceptionMessages.UserNotFound);
                    return response;
                }

                var roleFromDb = await _unitOfWork.RoleRepository.GetSingleAsync(x => x.Id == command.RoleId);
                if (roleFromDb == null)
                {
                    response.Data = null;
                    response.IsSucceed = false;
                    response.Errors.Add(ExceptionMessages.RoleNotFound);
                    return response;
                }

                if (command.FelStageid != null)
                {
                    var felStageFromDb = await _unitOfWork.FelStageRepository.GetSingleAsync(x => x.Id == command.FelStageid);
                    if (felStageFromDb == null)
                    {
                        response.Data = null;
                        response.IsSucceed = false;
                        response.Errors.Add(ExceptionMessages.FelStageNotFound);
                        return response;
                    }
                }

                /*userFromDb.RoleId = user.RoleId;
                if (roleFromDb.Name == "COE")
                {
                    userFromDb.FelStageId = null;
                    userFromDb.Area = null;
                }
                else
                {
                    userFromDb.FelStageId = user.FelStageid;
                    userFromDb.Area = user.Area;
                }*/

                userFromDb.RoleId = command.RoleId;
                userFromDb.FelStageId = command.FelStageid;
                userFromDb.Area = command.Area;

                if (command.IsAdmin != null)
                {
                    userFromDb.IsAdmin = command.IsAdmin.Value;
                }

                _unitOfWork.UserRepository.Update(userFromDb);

                if (command.HaveDuplicate)
                {
                    var userToRemove = await _unitOfWork.UserRepository.GetSingleAsync(a => a.Id == command.UserIdToRemove);
                    userToRemove.IsDeleted = true;
                    userToRemove.DeletedOn = DateTime.Now;
                    _unitOfWork.UserRepository.Update(userToRemove);
                }



                await _unitOfWork.CommitAsync();

                response.Data = null;
                response.IsSucceed = true;
                return response;
            }
        }
    }
}
