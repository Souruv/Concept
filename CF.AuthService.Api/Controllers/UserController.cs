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
    public class UserController : BaseApiController
    {/// <summary>
     /// Creates a New User.
     /// <param name="command"></param>
     /// </summary>
     /// <returns></returns>
     /// 
        ILoggedInUserService _loggedInUserService;
        public UserController(ILoggedInUserService loggedInUserService)
        {
            _loggedInUserService = loggedInUserService;
        }
        [HttpPost]
       // [Authorize]
        [Route("Create")]
       // [AllowAnonymous]
       // [ApiAuthorizationFilter(new[] { UserRole.AdminUser })]

        public async Task<IActionResult> Create(CreateUserCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPost]
        [Route("CreateUsers")]
        public async Task<IActionResult> CreateUsers(CreateUsersCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpGet]
        [Route("GetLoggedInUser")]
        //[AllowAnonymous]
        public async Task<IActionResult> GetLoggedInUser()
        {
            return Ok(await Mediator.Send(new GetUserByIdQuery { Id = (Guid)_loggedInUserService.Id }));
        }
        /// <summary>
        /// Gets all Users.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllUsersQuery()));
        }


        [HttpGet]
        [Route("GetAssignedUser")]
        [AllowAnonymous]
        public async Task<IActionResult> GetUserByRoleStageArea([FromQuery] GetAssignedUserQuery query)
        {
            return Ok(await Mediator.Send(query));
        }
        //[HttpGet("{role}")]
        //[Route("SearchByRole")]
        //public async Task<IActionResult> SearchByRole(int role)
        //{
        //    return Ok(await Mediator.Send(new GetAllUsersFilteredQuery { Role = role }));
        //}

        [HttpGet()]
        [Route("GetAdministrators")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAdministrators()
        {
            return Ok(await Mediator.Send(new GetFilteredUsersQuery { IsAdmin = true }));
        }

        [HttpGet()]
        [Route("GetFilteredUser")]
        [AllowAnonymous]
        public async Task<IActionResult> GetFilteredUser([FromQuery] GetFilteredUsersQuery query)
        {
            return Ok(await Mediator.Send(query));
        }

        [HttpGet()]
        [Route("GetNormalUsers")]
        public async Task<IActionResult> GetNormalUsers()
        {
            return Ok(await Mediator.Send(new GetFilteredUsersQuery { IsAdmin = false }));
        }


        /// <summary>
        /// Gets User Entity by Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            return Ok(await Mediator.Send(new GetUserByIdQuery { Id = id }));
        }
        /// <summary>
        /// Deletes User Entity based on Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete()]
        [Route("Delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Ok(await Mediator.Send(new DeleteUserByIdCommand { Id = id }));
        }


        /// <summary>
        /// Updates the User Entity based on Id.   
        /// </summary>
        /// <param name="id"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut()]
        [Route("Update")]
        public async Task<IActionResult> Update(UpdateUserCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPut()]
        [Route("UpdateUsers")]
        [AllowAnonymous]
        public async Task<IActionResult> Update(UpdateUsersCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPut()]
        [Route("UpdateUserRole")]
        public async Task<IActionResult> UpdateUserRole(UpdateUserRoleCommand command)
        {
            //if (id != command.Id)
            //{
            //    return BadRequest();
            //}
            return Ok(await Mediator.Send(command));
        }

        [HttpGet()]
        [Route("GetFilteredGraphUsers")]
        [AllowAnonymous]
        public async Task<IActionResult> GetFilteredGraphUsers([FromQuery] GetFilteredGraphUsersQuery query)
        {
            return Ok(await Mediator.Send(query));
        }


    }
}
