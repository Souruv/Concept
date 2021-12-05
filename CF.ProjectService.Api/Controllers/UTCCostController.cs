using CF.ProjectService.Application.Features.ProjectFeatures.Commands;
using CF.ProjectService.Application.Features.ProjectFeatures.Queries;
using CF.ProjectService.Application.Features.UTCCostFeature.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CF.ProjectService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UTCCostController : BaseApiController
    {
        [HttpPost()]
        [Route("GetUtcCost")]
        [AllowAnonymous]
        public async Task<IActionResult> GetUTCCost([FromBody] GetUTCCostQuery query)
        {
            return Ok(await Mediator.Send(query));
        }

        [HttpGet()]
        [Route("GetCountryListWithCost")]
        [AllowAnonymous]
        public async Task<IActionResult> GetCountryListWithCost([FromQuery] GetCountryListWithCostQuery query)
        {

            return Ok(await Mediator.Send(query));
        }
    }
}
