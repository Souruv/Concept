using CF.AuthService.Application.Common.Interfaces;
using CF.AuthService.Application.Entities;
using CF.AuthService.Application.Features.UserFeatures.Dto;
using CF.AuthService.Application.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CF.AuthService.Application.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<AppUser> CheckDuplicateUser(UpdateUserDto userDto)
        {
            if (userDto.FelStageId != null && !string.IsNullOrEmpty(userDto.Area))
            {
                var userFromDb = await _unitOfWork.UserRepository.Filter(x => x.RoleId == userDto.RoleId
                     && x.FelStageId == userDto.FelStageId && x.Area.Trim() == userDto.Area.Trim()
                     && x.Id != userDto.Id
                ).FirstOrDefaultAsync();

                return userFromDb != null ? userFromDb : null;
            }

            return null;
        }
    }
}
