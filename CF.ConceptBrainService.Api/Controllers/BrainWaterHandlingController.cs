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
    public class BrainWaterHandlingController :  BaseApiController
    {
        private readonly IConfiguration _config;
        public BrainWaterHandlingController(IConfiguration config)
        {
            _config = config;
        }
        [HttpGet]
        [Route("GetWaterDisposal")]
        public async Task<IActionResult> GetWaterDisposalAsync()
        {
            return Ok(await Mediator.Send(new GetAllWaterDisposalSettingQuery()));
        }

        [HttpPost]
        [Route("SaveWaterDisposal")]
        public async Task<IActionResult> SaveWaterDisposalSetting(SaveWaterDisposalSettingCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete]
        [Route("DeleteWaterDisposal")]
        public async Task<IActionResult> DeleteWaterDisposalSetting([FromQuery] DeleteWaterDisposalSettingCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpGet]
        [Route("GetPwtInjection")]
        public async Task<IActionResult> GetPwtInjectionAsync()
        {
            return Ok(await Mediator.Send(new GetAllPwtInjectionSettingQuery()));
        }

        [HttpPost]
        [Route("SavePwtInjection")]
        public async Task<IActionResult> SavePwtInjectionSetting(SaveBrainPwtInjectionSettingCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete]
        [Route("DeletePwtInjection")]
        public async Task<IActionResult> DeletePwtInjectionSetting([FromQuery] DeleteBrainPwtInjectionSettingCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpGet]
        [Route("GetExternalWaterInjection")]
        public async Task<IActionResult> GetExternalWaterInjectionAsync()
        {
            return Ok(await Mediator.Send(new GetAllBrainExternalWaterInjectionSettingQuery()));
        }

        [HttpPost]
        [Route("SaveExternalWaterInjection")]
        public async Task<IActionResult> SaveExternalWaterInjectionSetting(SaveBrainExternalWaterInjectionSettingCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete]
        [Route("DeleteExternalWaterInjection")]
        public async Task<IActionResult> DeleteExternalWaterInjectionSetting([FromQuery] DeleteBrainExternalWaterInjectionSettingCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpGet]
        [Route("GetFilteredWaterDisposalList")]
        public async Task<IActionResult> GetFilteredWaterDisposalListAsync([FromQuery] GetWaterDisposalByInputFilteredSettingQuery query)
        {
            return Ok(await Mediator.Send(query));
        }

        [HttpGet]
        [Route("GetFilteredPwtInjectionList")]
        public async Task<IActionResult> GetFilteredPwtInjectionListAsync([FromQuery] GetPwtInjectionByInputFilteredSettingQuery query)
        {
            return Ok(await Mediator.Send(query));
        }

        [HttpGet]
        [Route("GetFilteredExternalWaterInjectionList")]
        public async Task<IActionResult> GetFilteredExternalWaterInjectionListAsync([FromQuery] GetExternalWaterInjectionByInputFilteredSettingQuery query)
        {
            return Ok(await Mediator.Send(query));
        }
    }
}
