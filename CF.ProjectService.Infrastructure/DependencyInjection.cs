
using CF.ProjectService.Application.Common.Interfaces;
using CF.ProjectService.Persistence;
using Conceptor.Infrastructure.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;


namespace CF.ProjectService.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddPersistence(configuration);
            services.AddTransient(typeof(IGraphService), typeof(GraphService));
            services.AddTransient(typeof(IMathHelper), typeof(MathHelper));

            services.AddTransient(typeof(IAzureStorageService), typeof(AzureStorageService));

            services.AddTransient(typeof(IAuthService), typeof(AuthService));
            return services;
        }
    }
}
