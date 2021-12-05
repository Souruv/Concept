﻿using CF.AuthService.Application.Common.Interfaces;
using CF.AuthService.Application.Features.UserFeatures.Dto;
using CF.AuthService.Application.Features.UserFeatures.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using System.Security.Claims;

namespace CF.AuthService.Api.Services
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
                return User.Id;
                //return new Guid("4c82aa22-3de0-aaf8-ca37-007e7e592a89");
            }
        }

        public string Email { get { return User.Email; } }

        public AppUserDto User
        {
            get
            {

                if (_User == null)
                {
                    LoadLoggedinuser();
                }

                return _User;
            }
        }

        private void LoadLoggedinuser()
        {
            var email = _httpContextAccessor.HttpContext.User.Claims.Where(row => row.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name").Select(row => row.Value).SingleOrDefault();
            var mediator = (IMediator)_httpContextAccessor.HttpContext.RequestServices.GetService(typeof(IMediator));
            _User = mediator.Send(new GetUserByEmailQuery
            {
                Email = email
            }).Result;
        }
    }
}
