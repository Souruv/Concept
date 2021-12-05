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
    public class BrainPressureProtectionController : BaseApiController
    {
        private readonly IConfiguration _config;
        public BrainPressureProtectionController(IConfiguration config)
        {
            _config = config;
        }
        [HttpGet]
        [Route("GetPressureProtection")]
        public async Task<IActionResult> GetPressureProtectionAsync()
        {
            return Ok(await Mediator.Send(new GetAllBrainPressureProtectionSettingQuery()));
        }

        [HttpPost]
        [Route("SavePressureProtection")]
        public async Task<IActionResult> SavePressureProtectionSetting(SaveBrainPressureProtectionSettingCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete]
        [Route("DeletePressureProtection")]
        public async Task<IActionResult> DeletePressureProtectionSetting([FromQuery] DeleteBrainPressureProtectionSettingCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpGet]
        [Route("GetFilteredPressureProtectionList")]
        public async Task<IActionResult> GetFilteredPressureProtectionListAsync([FromQuery] GetPressureProtectionByInputFilteredSettingQuery query)
        {
            return Ok(await Mediator.Send(query));
        }
    }
}
