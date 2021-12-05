
using CF.ConceptBrainService.Application.Common.Interfaces;
using CF.ConceptBrainService.Persistence;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CF.ConceptBrainService.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddPersistence(configuration);
            //services.AddTransient(typeof(IGraphService), typeof(GraphService));
            //services.AddTransient(typeof(IMathHelper), typeof(MathHelper));
            return services;
        }
    }
}
