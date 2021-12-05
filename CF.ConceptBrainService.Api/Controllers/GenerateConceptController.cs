using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CF.ConceptBrainService.Application.Features.GenerateConceptFeatures.Query;
using Microsoft.AspNetCore.Authorization;

namespace CF.ConceptBrainService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenerateConceptController : BaseApiController
    {
        private readonly IConfiguration _config;
        public GenerateConceptController(IConfiguration config)
        {
            _config = config;
        }

        [HttpGet]
        [Route("GetConceptsList")]
        public async Task<IActionResult> GetConceptsListAsync([FromQuery] GetConceptByProjectRevisionIdQuery query)
        {
            return Ok(await Mediator.Send(query));
        }
    }
}
