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
    public class BrainTreeTypeController : BaseApiController
    {
        private readonly IConfiguration _config;
        public BrainTreeTypeController(IConfiguration config)
        {
            _config = config;
        }
        [HttpGet]
        [Route("GetTreeType")]
        public async Task<IActionResult> GetTreeTypeAsync()
        {
            return Ok(await Mediator.Send(new GetAllTreeTypeQuery()));
        }

        [HttpPost]
        [Route("SaveTreeType")]
        public async Task<IActionResult> SaveTreeTypeSetting(SaveBrainTreeTypeSettingCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete]
        [Route("DeleteTreeType")]
        public async Task<IActionResult> DeleteTreeTypeSetting([FromQuery] DeleteBrainTreeTypeSettingCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpGet]
        [Route("GetFilteredTreeTypeList")]
        public async Task<IActionResult> GetFilteredTreeTypeListAsync([FromQuery] GetTreeTypeByInputFilteredQuery query)
        {
            return Ok(await Mediator.Send(query));
        }
    }
}
