using CF.CostBrainService.Application.Features.HUCHookupCost.Command;
using CF.CostBrainService.Application.Features.HUCHookupCost.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;


namespace CF.CostBrainService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HUCHookupAndCommisionEstController : BaseApiController
    {
        [HttpGet()]
        [Route("GetHUCDefaultValues")]
        public async Task<IActionResult> GetHUCDefaultValues([FromQuery]GetHUCDefaultValuesQuery query)
        {
            return Ok(await Mediator.Send(query));
        }

        [HttpPost()]
        [Route("CalculateHUCHookupCost")]
        public async Task<IActionResult> CalculateHUCHookupCost(CalculateHUCHookupCostCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPost()]
        [Route("DownloadCostSumaryExcelFile")]
        public async Task<IActionResult> DownloadCostSumaryExcelFile(GetExcelFile command)
        {
            var stream = await Mediator.Send(command);
            string fileName = $"HUC Report {DateTime.Now.ToString("MM/dd/yyyy")}.xlsx";
            stream.Position = 0;
            return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
        }
    }
}
