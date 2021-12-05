using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CF.ProjectService.Api.Attributes;
using CF.ProjectService.Api.Controllers;
using CF.ProjectService.Application.Common.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Conceptor.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : BaseApiController
    {
        [HttpGet]
        [Route("GetAnonyTestAnonymousmous")]
        [AllowAnonymous]
        public  IActionResult TestAnonymous()
        {
            return Ok("for everyone");
        }

        [HttpGet]
        [Route("TestUser")]
        public  IActionResult TestUser()
        {
            return Ok("for user");
        }
        [HttpGet]
        [Route("TestAdminUserWithAttr")]
        [AppAuthorizeUpto(UserRole.AdminUser)]
        public IActionResult TestAdminUserWithAttr()
        {
            return Ok("for user WithAttr");
        }

        [HttpGet]
        [Route("TestAdminUser")]
        [AppAuthorizeUpto(UserRole.AdminUser)]
        public  IActionResult TestAdminUser()
        {
            return Ok("for AdminUser");
        }

        [HttpGet]
        [Route("TestAdmin")]
        [AppAuthorizeUpto(UserRole.AdminUser)]
        public  IActionResult TestAdmin()
        {
            return Ok("for super admin");
        }
    }
}
