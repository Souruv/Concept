using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CF.ConceptBrainService.Application.Features.ProjectConceptQueueFeature.Queries;
using CF.ConceptBrainService.Application.Features.ProjectConceptQueueFeature.Command;

namespace CF.ConceptBrainService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectConceptQueueController : BaseApiController
    {
        private readonly IConfiguration _config;
        public ProjectConceptQueueController(IConfiguration config)
        {
            _config = config;
        }

        [HttpGet]
        [Route("GetProjectConceptQueueById")]
        public async Task<IActionResult> GetProjectConceptQueueByIdAsync([FromQuery] GetProjectConceptQueueByIdQuery query)
        {
            return Ok(await Mediator.Send(query));
        }

        [HttpPost]
        [Route("SaveProjectConceptQueue")]
        public async Task<IActionResult> SaveProjectConceptQueueAsync(SaveProjectConceptQueueCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
