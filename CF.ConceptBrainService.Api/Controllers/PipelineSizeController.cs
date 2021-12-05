using CF.ConceptBrainService.Application.Features.PipelineSizeSettingFeatures.Commands;
using CF.ConceptBrainService.Application.Features.PipelineSizeSettingFeatures.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CF.ConceptBrainService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PipelineSizeController : BaseApiController
    {
        private readonly IConfiguration _config;
        public PipelineSizeController(IConfiguration config)
        {
            _config = config;
        }
        [HttpGet]
        [Route("GetFlowlineRatingSettings")]
        public async Task<IActionResult> GetFlowlineRatingSettingsAsync()
        {
            return Ok(await Mediator.Send(new GetFlowlineRatingSettingsQuery()));
        }
        [HttpGet]
        [Route("GetPipelineSizeSettings")]
        public async Task<IActionResult> GetPipelineSizeSettingsAsync([FromQuery] GetPipelineSizeSettingsQuery query)
        {
            return Ok(await Mediator.Send(query));
        }
        [HttpGet]
        [Route("GetFlowlineSizeSettings")]
        public async Task<IActionResult> GetFlowlineSizeSettings([FromQuery] GetFlowlineSizeSettingsQuery query)
        {
            return Ok(await Mediator.Send(query));
        }
        [HttpPost]
        [Route("SaveLiquidPipelineSizeSetting")]
        public async Task<IActionResult> SaveLiquidPipelineSizeSetting(SaveLiquidPipelineSizeSettingCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
        [HttpPost]
        [Route("DeleteLiquidPipelineSizeSetting")]
        public async Task<IActionResult> DeleteLiquidPipelineSizeSetting(DeleteLiquidPipelineSizeSettingCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
        [HttpPost]
        [Route("SavePipelineSizeCalcSetting")]
        public async Task<IActionResult> SavePipelineSizeCalcSetting(SavePipelineSizeCalcSettingCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
        [HttpPost]
        [Route("DeletePipelineSizeCalcSetting")]
        public async Task<IActionResult> DeletePipelineSizeCalcSetting(DeletePipelineSizeCalcSettingCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
        [HttpPost]
        [Route("SavePipelineRatingSetting")]
        public async Task<IActionResult> SavePipelineRatingSetting(SavePipelineRatingBoundarySettingCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
        [HttpPost]
        [Route("DeletePipelineRatingSetting")]
        public async Task<IActionResult> DeletePipelineRatingSetting(DeletePipelineRatingBoundarySettingCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
        [HttpPost]
        [Route("SaveFlowlineSettingCommand")]
        public async Task<IActionResult> SaveFlowlineSettingCommand(SaveFlowlineBoundarySettingCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
        [HttpPost]
        [Route("DeleteFlowlineSettingCommand")]
        public async Task<IActionResult> DeleteFlowlineSettingCommand(DeleteFlowlineBoundarySettingCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

    }
}
