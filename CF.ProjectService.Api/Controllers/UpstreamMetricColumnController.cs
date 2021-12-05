using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CF.ProjectService.Api.Controllers;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CF.ProjectService.Application.Features.UserFeatures.Commands;
using CF.ProjectService.Application.Features.UserFeatures.Queries;
using Microsoft.AspNetCore.Authorization;
using CF.ProjectService.Application.Common.Interfaces;
using CF.ProjectService.Application.Features.ProjectFeatures.Queries;
using CF.ProjectService.Application.Features.ProjectFeatures.Commands;
using Microsoft.Extensions.Configuration;
using CF.ProjectService.Application.Features.UpstreamMetricColumnFeatures.Queries;

namespace Conceptor.Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UpstreamMetricColumnController : BaseApiController
    {
        private readonly IConfiguration _config;
        public UpstreamMetricColumnController(IConfiguration config)
        {
            _config = config;
        }


        [HttpGet()]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllUpstreamMetricColumnQuery()));
        }

       
    }

   
}
