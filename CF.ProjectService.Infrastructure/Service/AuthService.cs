using CF.ProjectService.Application.Common.Interfaces;
using CF.ProjectService.Application.Common.Response;
using CF.ProjectService.Application.Features.UserFeatures.Dto;
using Microsoft.Extensions.Configuration;
using Microsoft.Graph;
//using Microsoft.Graph.Auth;
using Microsoft.Identity.Client;
using Newtonsoft.Json;
//using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Conceptor.Infrastructure.Service
{
    public class AuthService : IAuthService
    {
        IConfiguration _iConfig;
        public AuthService(IConfiguration iConfig)
        {
            _iConfig = iConfig;

        }

        public async Task<AuthUserDto> GetDetailByEmail(string email, string token)
        {
            AuthUserDto userDto = new AuthUserDto();
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", token);

                var url = _iConfig.GetValue<string>("ApiGatewayUrl");
                using (var response = await httpClient.GetAsync(url + "/api/User/GetLoggedInUser"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    userDto = JsonConvert.DeserializeObject<AuthUserDto>(apiResponse);
                }
            }
            return userDto;
        }

        public async Task<ApproverDto> GetApproverAsync(string area, Guid roleId, Guid felStageId, string token)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", token);

                var rs = new CustomResponse<ApproverDto>();
                var url = _iConfig.GetValue<string>("ApiGatewayUrl");
                using (var response = await httpClient.GetAsync(url + "/api/User/GetAssignedUser?Area=" + area + "&RoleId=" + roleId.ToString() + "&FelStageId=" + felStageId.ToString()))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    rs = JsonConvert.DeserializeObject<CustomResponse<ApproverDto>>(apiResponse);
                }

                if (rs.Data == null)
                {
                    using (var response = await httpClient.GetAsync(url + "/api/User/GetAssignedUser?Area=Other&RoleId=" + roleId.ToString() + "&FelStageId=" + felStageId.ToString()))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        rs = JsonConvert.DeserializeObject<CustomResponse<ApproverDto>>(apiResponse);
                    }
                }

                return rs.Data;
            }
        }
    }


}
