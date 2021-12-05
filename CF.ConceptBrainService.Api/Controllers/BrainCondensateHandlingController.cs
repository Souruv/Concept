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
    public class BrainCondensateHandlingController : BaseApiController
    {
        private readonly IConfiguration _config;
        public BrainCondensateHandlingController(IConfiguration config)
        {
            _config = config;
        }
        [HttpGet]
        [Route("GetCondensateHandling")]
        public async Task<IActionResult> GetCondensateHandlingAsync()
        {
            return Ok(await Mediator.Send(new GetAllBrainCondensateHandlingSettingQuery()));
        }

        [HttpPost]
        [Route("SaveCondensateHandling")]
        public async Task<IActionResult> SaveCondensateHandlingSetting(SaveBrainCondensateHandlingSettingCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete]
        [Route("DeleteCondensateHandling")]
        public async Task<IActionResult> DeleteCondensateHandlingSetting([FromQuery] DeleteBrainCondensateHandlingSettingCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpGet]
        [Route("GetFilteredCondensateHandlingList")]
        public async Task<IActionResult> GetFilteredCondensateHandlingListAsync([FromQuery] GetCondensateHandlingByInputFilteredSettingQuery query)
        {
            return Ok(await Mediator.Send(query));
        }

    }
}
