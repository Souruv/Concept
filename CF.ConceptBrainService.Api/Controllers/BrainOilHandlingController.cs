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
    public class BrainOilHandlingController : BaseApiController
    {
        private readonly IConfiguration _config;
        public BrainOilHandlingController(IConfiguration config)
        {
            _config = config;
        }

        [HttpGet]
        [Route("GetOilHandling")]
        public async Task<IActionResult> GetOilHandlingAsync()
        {
            return Ok(await Mediator.Send(new GetAllOilHandlingSettingQuery()));
        }

        [HttpPost]
        [Route("SaveOilHandling")]
        public async Task<IActionResult> SaveOilHandlingSetting(SaveOilHandlingSettingCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete]
        [Route("DeleteOilHandling")]
        public async Task<IActionResult> DeleteOilHandlingSetting([FromQuery] DeleteOilHandlingSettingCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpGet]
        [Route("GetFilteredOilHandlingList")]
        public async Task<IActionResult> GetFilteredOilHandlingListAsync([FromQuery] GetOilHandlingByInputFilteredSettingQuery query)
        {
            return Ok(await Mediator.Send(query));
        }

    }
}
