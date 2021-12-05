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
    public class BrainSubstructureController : BaseApiController
    {
        private readonly IConfiguration _config;
        public BrainSubstructureController(IConfiguration config)
        {
            _config = config;
        }
        [HttpGet]
        [Route("GetSubstructure")]
        public async Task<IActionResult> GetSubstructureAsync()
        {
            return Ok(await Mediator.Send(new GetAllBrainSubstructureSettingQuery()));
        }

        [HttpPost]
        [Route("SaveSubstructure")]
        public async Task<IActionResult> SaveSubstructureSetting(SaveBrainSubstructureSettingCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete]
        [Route("DeleteSubstructure")]
        public async Task<IActionResult> DeleteSubstructureSetting([FromQuery] DeleteBrainSubstructureSettingCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpGet]
        [Route("GetFilteredSubstructureList")]
        public async Task<IActionResult> GetFilteredSubstructureListAsync([FromQuery] GetSubstructureByInputFilteredSettingQuery query)
        {
            return Ok(await Mediator.Send(query));
        }
    }
}
