using AutoMapper;
using CF.AuthService.Application.Common.Exceptions;
using CF.AuthService.Application.Common.Interfaces;
using CF.AuthService.Application.Entities;
using CF.AuthService.Application.Features.UserFeatures.Dto;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CF.AuthService.Application.Features.UserFeatures.Commands
{
    public class UpdateUsersCommand : IRequest<CustomResponse<AppUserDto>>
    {
        public List<UpdateUserDto> Users { get; set; }
        public class UpdateUsersCommandHandler : IRequestHandler<UpdateUsersCommand, CustomResponse<AppUserDto>>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;
            public UpdateUsersCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }
            public async Task<CustomResponse<AppUserDto>> Handle(UpdateUsersCommand command, CancellationToken cancellationToken)
            {
                CustomResponse<AppUserDto> response = new CustomResponse<AppUserDto>();
                foreach (var user in command.Users)
                {
                    var existedUser = await GetDuplicateUser(user, command.Users);
                    if (existedUser != null)
                    {
                        response.Data = _mapper.Map<AppUserDto>(existedUser);
                        response.IsSucceed = false;
                        response.Message = "Existed user";
                        response.Errors.Add(ExceptionMessages.ExistedUser);
                        return response;
                    }

                    var userFromDb = await _unitOfWork.UserRepository.GetSingleAsync(a => a.Id == user.Id);
                    if (userFromDb == null)
                    {
                        response.Data = null;
                        response.IsSucceed = false;
                        response.Errors.Add(ExceptionMessages.UserNotFound);
                        return response;
                    }

                    var roleFromDb = await _unitOfWork.RoleRepository.GetSingleAsync(x => x.Id == user.RoleId);
                    if (roleFromDb == null)
                    {
                        response.Data = null;
                        response.IsSucceed = false;
                        response.Errors.Add(ExceptionMessages.RoleNotFound);
                        return response;
                    }

                    if (user.FelStageId != null)
                    {
                        var felStageFromDb = await _unitOfWork.FelStageRepository.GetSingleAsync(x => x.Id == user.FelStageId);
                        if (felStageFromDb == null)
                        {
                            response.Data = null;
                            response.IsSucceed = false;
                            response.Errors.Add(ExceptionMessages.FelStageNotFound);
                            return response;
                        }
                    }

                    userFromDb.RoleId = user.RoleId;
                    userFromDb.FelStageId = user.FelStageId;
                    userFromDb.Area = user.Area;

                    if (user.IsAdmin != null)
                    {
                        userFromDb.IsAdmin = user.IsAdmin.Value;
                    }

                    _unitOfWork.UserRepository.Update(userFromDb);

                }

                await _unitOfWork.CommitAsync();

                response.Data = null;
                response.IsSucceed = true;
                return response;
            }

            private async Task<AppUser> GetDuplicateUser(UpdateUserDto userDto, List<UpdateUserDto> Users)
            {
                if (userDto.FelStageId != null && !string.IsNullOrEmpty(userDto.Area))
                {
                    var userFromDb = await _unitOfWork.UserRepository.GetSingleAsync(x => !x.IsDeleted && x.RoleId == userDto.RoleId && x.FelStageId == userDto.FelStageId && x.Area.Trim() == userDto.Area.Trim());
                    if (userFromDb != null)
                    {
                        var updateUser = Users.Where(x => x.Id == userFromDb.Id).FirstOrDefault();
                        if (updateUser == null ||
                            (updateUser != null && updateUser.FelStageId == userDto.FelStageId && updateUser.Area == userDto.Area))
                        {
                            return userFromDb;
                        }
                    }
                }

                return null;
            }
        }
    }
}
