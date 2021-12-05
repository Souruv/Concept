using CF.ConceptBrainService.Application.Features.WeightEstimateFeatures.Command;
using CF.ConceptBrainService.Application.Features.WeightEstimateFeatures.Queries;
using Microsoft.AspNetCore.Authorization;
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
    public class WeightEstimateController : BaseApiController
    {
        private readonly IConfiguration _config;
        public WeightEstimateController(IConfiguration config)
        {
            _config = config;
        }

        [HttpGet()]
        [Route("GetAllWeightEstimates")]
        public async Task<IActionResult> GetAllWeightEstimates([FromQuery] GetAllWeightEstimatesQuery query)
        {
            return Ok(await Mediator.Send(query));
        }

        [HttpGet()]
        [Route("GetWeightEstimateById")]
        public async Task<IActionResult> GetWeightEstimateById([FromQuery] GetWeightEstimateByIdQuery query)
        {
            return Ok(await Mediator.Send(query));
        }

        [HttpPost()]
        [Route("SaveWeightEstimate")]
        public async Task<IActionResult> SaveWeightEstimate(StoreWeightEstimateCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
        [HttpGet()]
        [Route("GetAllMasterEquipment")]
        public async Task<IActionResult> GetAllMasterEquipment([FromQuery] GetAllMasterEquipmentQuery query)
        {
            return Ok(await Mediator.Send(query));
        }
    }
}