using CF.ProjectService.Application.Features.UserFeatures.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CF.ProjectService.Application.Common.Interfaces
{
    public interface IGraphService
    {
        void Configure(string clientId, string clientSecret, string authority, string apiUrl);
        Task<List<AppUserDto>> Search(string searchText);
    }
}
