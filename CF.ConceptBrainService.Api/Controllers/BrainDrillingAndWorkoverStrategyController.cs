using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using CF.ConceptBrainService.Application.Features.ConceptBrainSettingFeatures.Queries;
using Microsoft.AspNetCore.Authorization;
using CF.ConceptBrainService.Application.Features.ConceptBrainSettingFeatures.Commands;

namespace CF.ConceptBrainService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrainDrillingAndWorkoverStrategyController : BaseApiController
    {
        private readonly IConfiguration _config;
        public BrainDrillingAndWorkoverStrategyController(IConfiguration config)
        {
            _config = config;
        }

        [HttpGet]
        [Route("GetDrillingAndWorkoverStrategy")]
        public async Task<IActionResult> GetDrillingAndWorkoverStrategyAsync()
        {
            return Ok(await Mediator.Send(new GetAllBrainDrillingAndWorkoverStrategySettingQuery()));
        }

        [HttpPost]
        [Route("SaveDrillingAndWorkoverStrategy")]
        public async Task<IActionResult> SaveDrillingAndWorkoverStrategySetting(SaveBrainDrillingAndWorkoverStrategySettingCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete]
        [Route("DeleteDrillingAndWorkoverStrategy")]
        public async Task<IActionResult> DeleteDrillingAndWorkoverStrategySetting([FromQuery] DeleteBrainDrillingAndWorkoverStrategySettingCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpGet]
        [Route("GetFilteredDrillingAndWorkoverStrategyList")]
        public async Task<IActionResult> GetFilteredDrillingAndWorkoverStrategyListAsync([FromQuery] GetDrillingAndWorkoverStrategyByInputFilteredSettingQuery query)
        {
            return Ok(await Mediator.Send(query));
        }
    }
}
