
using CF.AuthService.Application.Common.Interfaces;
using CF.AuthService.Application.Features.UserFeatures.Dto;
using Microsoft.Graph;
using CF.AuthService.Application.Common.Interfaces;
using CF.AuthService.Application.Features.UserFeatures.Dto;
using Microsoft.Extensions.Configuration;
using Microsoft.Graph;
//using Microsoft.Graph.Auth;
using Microsoft.Identity.Client;
//using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CF.AuthService.Infrastructure.Service
{
    public class GraphService : IGraphService
    {
        // IConfidentialClientApplication app;
        string _apiUrl;

        IConfidentialClientApplication confidentialClientApplication;
        //public GraphService(string clientId, string clientSecret, string authority)
        //{
        //    this.Configure(clientId, clientSecret, authority);
        //}
        public void Configure(string clientId, string clientSecret, string tenantId, string apiUrl)
        {


            confidentialClientApplication = ConfidentialClientApplicationBuilder
.Create(clientId)
.WithTenantId(tenantId)
.WithClientSecret(clientSecret)
.Build();

            //app = ConfidentialClientApplicationBuilder.Create(clientId)
            //    .WithClientSecret(clientSecret)
            //    .WithAuthority(new Uri(tenantId))
            //    .Build();
            _apiUrl = apiUrl;
        }

        //private async Task<AuthenticationResult> GetToken(string apiUrl)
        //{
        //string[] scopes = new string[] { $"{_apiUrl}.default" };
        //    AuthenticationResult result = null;
        //    try
        //    {
        //        result = await app.AcquireTokenForClient(scopes)
        //            .ExecuteAsync();
        //    }
        //    catch (MsalServiceException ex) when (ex.Message.Contains("AADSTS70011"))
        //    {
        //        // Invalid scope. The scope has to be of the form "https://resourceurl/.default"
        //        // Mitigation: change the scope to be as expected
        //        string sdfsd = "sdfd";

        //    }
        //    catch (Exception ex)
        //    {
        //        string sdfsd = "sdfd";
        //    }
        //    return result;
        //}

        public async Task<List<AppUserDto>> Search(string searchText)
        {


            List<AppUserDto> userList = new List<AppUserDto>();

            //ClientCredentialProvider authProvider = new ClientCredentialProvider(confidentialClientApplication);
            //IAuthenticationProvider clientCredentialProvider = new ClientCredentialProvider(confidentialClientApplication);
            //new Devi(confidentialClientApplication);

            var authenticationProvider = new GraphAuthenticationProvider(confidentialClientApplication, _apiUrl);



            GraphServiceClient graphClient = new GraphServiceClient(authenticationProvider);

            //            List<QueryOption> options = new List<QueryOption>
            //{
            //     new QueryOption("$search", "\"displayName:"+searchText+"\"")
            //};
            //            var users = await graphClient.Users.Request(options).Select("mail,displayName,givenName,postalCode").OrderBy("displayName").Top(10).GetAsync();

            var users = await graphClient.Users
                .Request()
                .Filter("startswith(displayName,'" + searchText + "')")
                .Select("mail,displayName,givenName,postalCode")
                .GetAsync();

            foreach (var user in users)
            {
                var userObj = new AppUserDto();

                if (user.DisplayName != null && user.DisplayName.Contains("("))
                {
                    userObj.Name = user.DisplayName.Split("(")[0];
                    userObj.DepartmentName = user.DisplayName.Split("(")[1].Split(")")[0];
                }
                else
                {
                    userObj.Name = user.DisplayName;
                }


                userObj.Email = user.Mail;


                userList.Add(userObj);
            }

            // 
            // var result = await GetToken(this._apiUrl);
            // var httpClient = new HttpClient();
            // var apiCaller = new GraphApiCallHelper(httpClient);
            //var resultObj= await apiCaller.CallWebApiAndProcessResultASync($"{_apiUrl}v1.0/users", result.AccessToken);
            // foreach (JProperty child in resultObj.Properties().Where(p => !p.Name.StartsWith("@")))
            // {
            //     string sdfsd1 = "sdfsd";
            //     //child.Value[0]["mail"].ToString()
            //     foreach (var obj in child.Value)
            //     {

            //         var user = new AppUserDto();
            //         user.Name = obj["displayName"].ToString();
            //         user.Email = obj["mail"].ToString();


            //         userList.Add(user);
            //     }
            //     //Console.WriteLine($"{child.Name} = {child.Value}");
            // }


            // string sdfsd = "sdfsd";
            return userList;
        }
    }


    public class GraphAuthenticationProvider : IAuthenticationProvider
    {
        public const string GRAPH_URI = "https://graph.microsoft.com/";
        IConfidentialClientApplication _confidentialClientApplication;
        string _apiUrl = string.Empty;
        public GraphAuthenticationProvider(IConfidentialClientApplication confidentialClientApplication, string apiUrl)
        {
            _confidentialClientApplication = confidentialClientApplication;
            _apiUrl = apiUrl;



        }

        public async Task AuthenticateRequestAsync(HttpRequestMessage httpRequestMessage)
        {
            string[] scopes = new string[] { $"{_apiUrl}.default" };
            //AuthenticationContext authContext = new AuthenticationContext($"https://login.microsoftonline.com/{_tenantId}");

            //ClientCredential creds = new ClientCredential(_clientId, _clientSecret);

            //AuthenticationResult authResult = await authContext.AcquireTokenAsync(GRAPH_URI, creds);
            AuthenticationResult authenticationResult = await _confidentialClientApplication.AcquireTokenForClient(scopes)
                        .WithForceRefresh(true)
                        .ExecuteAsync();



            httpRequestMessage.Headers.Add("Authorization", "Bearer " + authenticationResult.AccessToken);
        }
    }
}
