using CF.ProjectService.Application.Features.UserFeatures.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CF.ProjectService.Application.Common.Interfaces
{
    public interface IAuthService
    {
        Task<AuthUserDto> GetDetailByEmail(string email, string token);
        Task<ApproverDto> GetApproverAsync(string area, Guid roleId, Guid felStageId, string token);
    }
}
