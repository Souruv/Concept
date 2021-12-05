using CF.ProjectService.Application.Common.Enums;
using CF.ProjectService.Application.Common.Interfaces;
using CF.ProjectService.Application.Features.UserFeatures.Commands;
using CF.ProjectService.Application.Features.UserFeatures.Dto;
using CF.ProjectService.Application.Features.UserFeatures.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;


namespace CF.ProjectService.Api.Attributes
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
    public class AppAuthorizeUpto : ActionFilterAttribute
    {
        UserRole _role;
        public AppAuthorizeUpto(UserRole role) : base()
        {
            _role = role;
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            try
            {
                if (!context.Filters.Any(row => row is AllowAnonymousFilter) &&
                    !(context.ActionDescriptor as ControllerActionDescriptor)?.MethodInfo.GetCustomAttributes(true).Any(row => row is AllowAnonymousAttribute) == true
                    )
                {
                    if (context.HttpContext.User.Identity.IsAuthenticated)
                    {

                        var loggedInUserService = (ILoggedInUserService)context.HttpContext.RequestServices.GetService(typeof(ILoggedInUserService));
                        var user = loggedInUserService.User;

                        if (user != null)
                        {
                            
                            //if (user.Role == null)
                            //{
                            //    context.Result = new StatusCodeResult((int)HttpStatusCode.Forbidden);
                            //}
                            //else if (!((int)_role >= user.Role))
                            //{
                            //    context.Result = new UnauthorizedResult();

                            //}
                           
                        }
                        else
                        {
                            context.Result = new UnauthorizedResult();
                        }
                    }
                    else
                    {
                        context.Result = new UnauthorizedResult();
                    }
                }
            }
            catch (Exception)
            {
                context.Result = new BadRequestResult();
            }

            base.OnActionExecuting(context);
        }


    }
}
