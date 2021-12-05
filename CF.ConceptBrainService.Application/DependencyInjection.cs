using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using MediatR;
using AutoMapper;
using FluentValidation;
using CF.ConceptBrainService.Application.Common.Behaviours;
using CF.ConceptBrainService.Application.Services.Interfaces;
using CF.ConceptBrainService.Application.Common.Helper;
using CF.ConceptBrainService.Application.Services.Implementations;
using CF.ConceptBrainService.Application.Services.ServiceBus;
using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Azure;

namespace CF.ConceptBrainService.Application
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
            services.AddTransient(typeof(IWeightEstimateService),typeof(WeightEstimateService));

            //services.AddHostedService(typeof(ReceiveUserAddedBus));

            // services.AddTransient(typeof(ReceiveUserAddedBus));

          

           // services.AddTransient(typeof(IReceiveBusService),typeof(ReceiveUserAddedBus));
           // services.AddTransient(typeof(ISubscriptionClient),typeof(SubscriptionClient));

            services.AddTransient(typeof(IRuleEngine<,>), typeof(RuleEngine<,>));

            return services;
        }
    }
}
