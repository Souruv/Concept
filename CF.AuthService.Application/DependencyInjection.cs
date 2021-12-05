using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using MediatR;
using AutoMapper;
using FluentValidation;
using CF.AuthService.Application.Common.Behaviours;
using CF.AuthService.Application.Services.Interfaces;
using CF.AuthService.Application.Services.Implementations;
using CF.AuthService.Application.Services.ServiceBus;

namespace CF.AuthService.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            //var tt=  typeof(CF.AuthService.Application);
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());

            //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(PerformanceBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));
            services.AddTransient<ISenderService, SenderService>();
            services.AddTransient(typeof(IUserService), typeof(UserService));
            return services;
        }

    }
}
