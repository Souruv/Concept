using CF.ConceptBrainService.Application.Features.UserFeatures.Dto;
using CF.ConceptBrainService.Application.Features.UserFeatures.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CF.ConceptBrainService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class TestUserController : BaseApiController
    {
     
        [HttpGet]
        public async Task<IActionResult> GetByEmail(string email)
        {
            var getResult = await Mediator.Send(new GetUserByEmailQuery { Email = email });
            return Ok(getResult);
        }

        public async Task<IActionResult> getinfo(AppUserDto appUserDto)
        {
            var result = await Mediator.Send(new GetUserByEmailQuery { Email = appUserDto.Email });
            if (result == null)
            {
                await Mediator.Send(appUserDto);
            }

            return Ok();
        }


    }
}
