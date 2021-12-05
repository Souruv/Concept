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
    public class BrainGasContaminantMgmtController  : BaseApiController
    {private readonly IConfiguration _config;
    public BrainGasContaminantMgmtController(IConfiguration config)
    {
        _config = config;
    }

    [HttpGet]
    [Route("GetGasContaminantMgmt")]
    public async Task<IActionResult> GetGasContaminantMgmtAsync()
    {
        return Ok(await Mediator.Send(new GetAllBrainGasContaminantMgmtSettingQuery()));
    }

    [HttpPost]
    [Route("SaveGasContaminantMgmt")]
    public async Task<IActionResult> SaveGasContaminantMgmtSetting(SaveBrainGasContaminantMgmtSettingCommand command)
    {
        return Ok(await Mediator.Send(command));
    }

    [HttpDelete]
    [Route("DeleteGasContaminantMgmt")]
    public async Task<IActionResult> DeleteGasContaminantMgmtSetting([FromQuery] DeleteBrainGasContaminantMgmtSettingCommand command)
    {
        return Ok(await Mediator.Send(command));
    }

    [HttpGet]
    [Route("GetFilteredGasContaminantMgmtList")]
    public async Task<IActionResult> GetFilteredGasContaminantMgmtListAsync([FromQuery] GetGasContaminantMgmtByInputFilteredSettingQuery query)
    {
        return Ok(await Mediator.Send(query));
    }
}
}
