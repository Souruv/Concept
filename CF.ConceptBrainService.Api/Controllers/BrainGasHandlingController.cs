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
    public class BrainGasHandlingController : BaseApiController
    {
        private readonly IConfiguration _config;
        public BrainGasHandlingController(IConfiguration config)
        {
            _config = config;
        }

        [HttpGet]
        [Route("GetGasExport")]
        public async Task<IActionResult> GetGasExportAsync()
        {
            return Ok(await Mediator.Send(new GetAllGasExportQuery()));
        }

        [HttpPost]
        [Route("SaveGasExport")]
        public async Task<IActionResult> SaveGasExportSetting(SaveBrainGasExportSettingCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete]
        [Route("DeleteGasExport")]
        public async Task<IActionResult> DeleteGasExportSetting([FromQuery] DeleteBrainGasExportSettingCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpGet]
        [Route("GetFilteredGasExportList")]
        public async Task<IActionResult> GetFilteredGasExportListAsync([FromQuery] GetGasExportByInputFilteredQuery query)
        {
            return Ok(await Mediator.Send(query));
        }

        [HttpGet]
        [Route("GetGasInjection")]
        public async Task<IActionResult> GetGasInjectionAsync()
        {
            return Ok(await Mediator.Send(new GetAllGasInjectionQuery()));
        }

        [HttpPost]
        [Route("SaveGasInjection")]
        public async Task<IActionResult> SaveGasInjectionSetting(SaveBrainGasInjectionSettingCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete]
        [Route("DeleteGasInjection")]
        public async Task<IActionResult> DeleteGasInjectionSetting([FromQuery] DeleteBrainGasInjectionSettingCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpGet]
        [Route("GetFilteredGasInjectionList")]
        public async Task<IActionResult> GetFilteredGasInjectionListAsync([FromQuery] GetGasInjectionByInputFilteredQuery query)
        {
            return Ok(await Mediator.Send(query));
        }
        [HttpGet]
        [Route("GetGasDisposal")]
        public async Task<IActionResult> GetGasDisposalAsync()
        {
            return Ok(await Mediator.Send(new GetAllGasDisposalQuery()));
        }

        [HttpPost]
        [Route("SaveGasDisposal")]
        public async Task<IActionResult> SaveGasDisposalSetting(SaveBrainGasDisposalSettingCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete]
        [Route("DeleteGasDisposal")]
        public async Task<IActionResult> DeleteGasDisposalSetting([FromQuery] DeleteBrainGasDisposalSettingCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpGet]
        [Route("GetFilteredGasDisposalList")]
        public async Task<IActionResult> GetFilteredGasDisposalListAsync([FromQuery] GetGasDisposalByInputFilteredQuery query)
        {
            return Ok(await Mediator.Send(query));
        }
    }
}
