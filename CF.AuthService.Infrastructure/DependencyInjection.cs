
using Microsoft.Graph;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using CF.AuthService.Application.Common.Interfaces;
using CF.AuthService.Infrastructure.Service;
using CF.AuthService.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CF.AuthService.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddPersistence(configuration);
            services.AddTransient(typeof(IGraphService), typeof(GraphService));
            return services;
        }
    }
}
