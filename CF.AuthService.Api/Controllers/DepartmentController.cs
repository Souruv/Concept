using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CF.ProjectService.Application.Features.UserFeatures.Commands;

using Microsoft.AspNetCore.Authorization;
using CF.AuthService.Application.Common.Interfaces;
using CF.AuthService.Application.Features.UserFeatures.Commands;
using CF.AuthService.Application.Features.UserFeatures.Queries;
using CF.AuthService.Application.Common.Enums;
using CF.AuthService.Api.Attributes;
using System.Security.Claims;
using CF.AuthService.Api.Attributes.CustomAtributes;

namespace CF.AuthService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : BaseApiController
    {/// <summary>
     /// Creates a New User.
     /// </summary>
     /// <param name="command"></param>
     /// <returns></returns>
     /// 
        ILoggedInUserService _loggedInUserService;
        public DepartmentController(ILoggedInUserService loggedInUserService)
        {
            _loggedInUserService = loggedInUserService;
        }
        /// <summary>
        /// Gets all departments.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetAll")]
        //[AllowAnonymous]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllDepartmentsQuery()));
        }
    }
}
