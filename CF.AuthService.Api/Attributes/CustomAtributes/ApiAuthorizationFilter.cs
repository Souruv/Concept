
using CF.AuthService.Application.Common.Enums;
using CF.AuthService.Application.Common.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CF.AuthService.Api.Attributes.CustomAtributes
{
    public class ApiAuthorizationFilter : ActionFilterAttribute
    {
        UserRole[] _roles;
        public ApiAuthorizationFilter(UserRole[] roles) : base()
        {
            _roles = roles;
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            try
            {
                if (context.HttpContext.User.Identity.IsAuthenticated)
                {
                    var loggedInUserService = (ILoggedInUserService)context.HttpContext.RequestServices.GetService(typeof(ILoggedInUserService));
                    var user = loggedInUserService.User;
                    //if (!_roles.Contains((UserRole)user.Role))
                    //{
                    //    context.Result = new UnauthorizedResult();
                    //}
                }
                else
                {
                    context.Result = new UnauthorizedResult();
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
