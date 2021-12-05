using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using MediatR;
using AutoMapper;
using FluentValidation;
using CF.ProjectService.Application.Common.Behaviours;
using CF.ProjectService.Application.Services.Interfaces;
using CF.ProjectService.Application.Common.Helper;
using CF.ProjectService.Application.Services.Implementations;
using CF.ProjectService.Application.Common.Interfaces;

namespace CF.ProjectService.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, Assembly startupAssembly)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(startupAssembly, Assembly.GetExecutingAssembly());
            //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(PerformanceBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));

            services.AddTransient(typeof(IProjectDService), typeof(ProjectDService));
            services.AddTransient(typeof(IEvacuationOptionService), typeof(EvacuationOptionService));
            services.AddTransient(typeof(ICraDataService), typeof(CraDataService));
            services.AddTransient(typeof(IProjectReportService), typeof(ProjectReportService));
            services.AddScoped<IProjectNotificationService, ProjectNotificationService>();
            services.AddScoped<IProjectAuditLogService, ProjectAuditLogService>();
            services.AddTransient(typeof(IUtcCostService), typeof(UtcCostService));


            return services;
        }
    }
}
