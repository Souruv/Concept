using CF.ConceptBrainService.Application.Common.Interfaces;
using CF.ConceptBrainService.Application.Features.UserFeatures.Dto;
using CF.ConceptBrainService.Application.Features.UserFeatures.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using System.Security.Claims;

namespace CF.ConceptBrainService.Api.Services
{
    public class LoggedInUserService : ILoggedInUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LoggedInUserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        private AppUserDto _User { get; set; }
        public Guid Id
        {
            get
            {
                if (_User == null)
                {
                    LoadLoggedinuser();
                }
                //return User.Id;
                return new Guid("08365d46-e1c7-47c6-acb4-2b9f20f4f8c3");
            }
        }

        public string Email { get { return User.Email; } }

        public AppUserDto User
        {
            get
            {

                if (_User == null)
                {
                    //var name = context.HttpContext.User.Claims.Where(row => row.Type == "name").Select(row => row.Value).SingleOrDefault();
                    //var email = _httpContextAccessor.HttpContext.User.Claims.Where(row => row.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name").Select(row => row.Value).SingleOrDefault();
                    //var nameIdentifier = context.HttpContext.User.Claims.Where(row => row.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier").Select(row => row.Value).SingleOrDefault();
                    //var userPrincipal = context.HttpContext.User.Claims.Where(row => row.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/upn").Select(row => row.Value).SingleOrDefault();


                    //var mediator = (IMediator)_httpContextAccessor.HttpContext.RequestServices.GetService(typeof(IMediator));
                    //_User = mediator.Send(new GetUserByEmailQuery
                    //{
                    //    Email = email
                    //}).Result;

                    LoadLoggedinuser();
                }

                return _User;
            }
        }

        private void LoadLoggedinuser()
        {
            var email = _httpContextAccessor.HttpContext.User.Claims.Where(row => row.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name").Select(row => row.Value).SingleOrDefault();
            //var nameIdentifier = context.HttpContext.User.Claims.Where(row => row.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier").Select(row => row.Value).SingleOrDefault();
            //var userPrincipal = context.HttpContext.User.Claims.Where(row => row.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/upn").Select(row => row.Value).SingleOrDefault();


            var mediator = (IMediator)_httpContextAccessor.HttpContext.RequestServices.GetService(typeof(IMediator));
            _User = mediator.Send(new GetUserByEmailQuery
            {
                Email = email
            }).Result;
        }

    }
}
