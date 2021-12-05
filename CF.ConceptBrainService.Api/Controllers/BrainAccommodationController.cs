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
    public class BrainAccommodationController : BaseApiController
    {
        private readonly IConfiguration _config;
        public BrainAccommodationController(IConfiguration config)
        {
            _config = config;
        }

        [HttpGet]
        [Route("GetAccommodation")]
        public async Task<IActionResult> GetAccommodationAsync()
        {
            return Ok(await Mediator.Send(new GetAllBrainAccommodationSettingQuery()));
        }

        [HttpPost]
        [Route("SaveAccommodation")]
        public async Task<IActionResult> SaveAccommodationSetting(SaveBrainAccommodationSettingCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete]
        [Route("DeleteAccomodation")]
        public async Task<IActionResult> DeleteAccomodationSetting([FromQuery] DeleteBrainAccommodationSettingCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpGet]
        [Route("GetFilteredAccomodationList")]
        public async Task<IActionResult> GetFilteredAccomodationListAsync([FromQuery] GetAccommodationByInputFilteredSettingQuery query)
        {
            return Ok(await Mediator.Send(query));
        }
    }
}
