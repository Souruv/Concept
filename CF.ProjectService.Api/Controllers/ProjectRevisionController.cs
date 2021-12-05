using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CF.ProjectService.Application.Features.UserFeatures.Commands;
using CF.ProjectService.Application.Features.UserFeatures.Queries;
using Microsoft.AspNetCore.Authorization;
using CF.ProjectService.Application.Common.Interfaces;
using CF.ProjectService.Application.Features.ProjectFeatures.Queries;
using CF.ProjectService.Application.Features.ProjectFeatures.Commands;
using CF.ProjectService.Api.Controllers;

namespace Conceptor.Api.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectRevisionController : BaseApiController
    {
        public ProjectRevisionController()
        {
        }


        //[HttpGet()]
        //[Route("GetFilteredProject")]
        ////[AllowAnonymous]
        //public async Task<IActionResult> GetFilteredProject([FromQuery] GetFilteredProjectsQuery query)
        //{
        //    return Ok(await Mediator.Send(query));
        //}

        //[HttpPost]
        //[Route("CopyProject")]
        //public async Task<IActionResult> CopyProject(CopyProjectCommand command)
        //{
        //    return Ok(await Mediator.Send(command));
        //}

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Ok(await Mediator.Send(new DeleteRevisiontByIdCommand { Id = id }));
        }

        [HttpPost]
        [Route("Restore")]
        public async Task<IActionResult> Restore(RestoreRevisionByIdCommand command )
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpGet]
        [Route("GetProjectStages")]
        public async Task<IActionResult> GetAllProjectStages([FromQuery]GetProjectStagesQuery query)
        {
            return Ok(await Mediator.Send(query));
        }
    }
}
