using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using MediatR;
using AutoMapper;
using FluentValidation;
using CF.CostBrainService.Application.Common.Behaviours;
using CF.CostBrainService.Application.Services.Interfaces;
using CF.CostBrainService.Application.Services.Implementations;

namespace CF.CostBrainService.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));
            services.AddTransient(typeof(IHUCHookupService), typeof(HUCHookupService));
            services.AddTransient(typeof(IMathHelper),typeof(MathHelperService));

            return services;
        }
    }
}
