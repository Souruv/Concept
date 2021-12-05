using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authorization;
using CF.ConceptBrainService.Application.Common.Enums;
using CF.ConceptBrainService.Api.Attributes;

namespace CF.ConceptBrainService.Api.Controllers
{
   // [Authorize()]
   // [AppAuthorizeUpto(UserRole.User)]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public abstract class BaseApiController : ControllerBase
    {
        private IMediator _mediator;

        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
    }
}
