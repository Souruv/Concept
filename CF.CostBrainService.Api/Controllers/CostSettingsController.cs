using CF.CostBrainService.Application.Features.CostBrainSettings.Commands;
using CF.CostBrainService.Application.Features.CostBrainSettings.Queries;
using CF.CostBrainService.Application.Features.GeneralSettings.Queries;
using CF.CostBrainService.Application.Features.TICostCalculation.Queries;
using CF.CostBrainService.Application.Features.TICostCalculation.Commands;
using CF.CostBrainService.Application.Features.GeneralSettings.Commands;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CF.CostBrainService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CostSettingsController : BaseApiController
    {
        [HttpGet()]
        [Route("GetCostSettings")]
        public async Task<IActionResult> GetCostSettings([FromQuery] GetCostSettingsQuery query)
        {
            return Ok(await Mediator.Send(query));
        }

        [HttpGet()]
        [Route("GetCostCountry")]
        public async Task<IActionResult> GetCostCountry()
        {
            return Ok(await Mediator.Send(new GetCostCountryQuery()));
        }

        // PUT api/<CostSetting>
        [HttpPut()]
        [Route("UpdateCost")]
        public async Task<IActionResult> UpdateCost([FromQuery] Guid countryCode, [FromBody] UpdateCostSettingsCommand command)
        {
            command.CountryCode = countryCode;
            return Ok(await Mediator.Send(command));
        }

        //Delete single row
        [HttpDelete()]
        [Route("DeleteSingleCost")]
        public async Task<IActionResult> DeleteSingleCost([FromQuery] DeleteCostSettingsCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpGet()]
        [Route("GetFabrication")]
        public async Task<IActionResult> GetFabricationSettings([FromQuery] GetFabricationSettingsQuery query)
        {
            return Ok(await Mediator.Send(query));
        }

        [HttpPut()]
        [Route("UpdateFabrication")]
        public async Task<IActionResult> UpdateFabrication([FromQuery] Guid countryCode, [FromBody] UpdateFabricationSettingsCommand command)
        {
            command.CountryCode = countryCode;
            return Ok(await Mediator.Send(command));
        }
        [HttpDelete()]
        [Route("DeleteSingleFabrication")]
        public async Task<IActionResult> DeleteFabrication([FromQuery] DeleteFabricationSettingsCommand command)
        {
            return Ok(await Mediator.Send(command));
        }       

        [HttpGet()]
        [Route("GetTIOptimizationCost")]
        public async Task<IActionResult> GetTIOptimizationCost([FromQuery] GetTIOptimizationCostQuery query)
        {
            return Ok(await Mediator.Send(query));
        }
        [HttpGet()]
        [Route("GetGeneralSettingData")]
        public async Task<IActionResult> GetGeneralSettingData()
        {
            return Ok(await Mediator.Send(new GetGeneralSettingsQuery()));
        }
        [HttpPut()]
        [Route("UpdateTIOptimizationCost")]
        public async Task<IActionResult> UpdateTIOptimizationCost([FromBody] UpdateTIOptimizationCostCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
        [HttpPut()]
        [Route("UpdateGeneralSettingData")]
        public async Task<IActionResult> UpdateGeneralSettingData([FromBody] UpdateGeneralSettingsCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
