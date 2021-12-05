using CF.AuthService.Application.Entities;
using CF.AuthService.Application.Features.UserFeatures.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CF.AuthService.Application.Services.Interfaces
{
    public interface IUserService
    {
        public Task<AppUser> CheckDuplicateUser(UpdateUserDto userDto);
    }
}
