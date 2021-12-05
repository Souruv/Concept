using CF.ProjectService.Application.Features.UserFeatures.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace CF.ProjectService.Application.Common.Interfaces
{
    public interface ILoggedInUserService
    {
       Guid Id { get;  }

        string Email { get; }

        AuthUserDto User { get; }
    }
}
