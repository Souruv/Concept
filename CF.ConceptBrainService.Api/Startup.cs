using CF.ConceptBrainService.Application;
using CF.ConceptBrainService.Application.Common.Interfaces;
using CF.ConceptBrainService.Infrastructure;
using CF.ConceptBrainService.Api.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.AzureAD.UI;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Azure.ServiceBus;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CF.ConceptBrainService.Application.Services.ServiceBus;
using CF.ConceptBrainService.Application.Services.Implementations;
using Microsoft.Extensions.Azure;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Reflection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Security.Claims;
using static CF.ConceptBrainService.Application.Features.UserFeatures.Command.CreateUserCommand;
using CF.ConceptBrainService.Persistence;
using AutoMapper;

namespace CF.ConceptBrainService.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration) //, ISubscriptionClient subscriptionClient)
        {
            Configuration = configuration;
           // _subscriptionClient = subscriptionClient;
        }
        public IHttpContextAccessor _httpContextAccessor { get; set; }
        public IConfiguration Configuration { get; }
      //  public ISubscriptionClient _subscriptionClient;

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(AzureADDefaults.BearerAuthenticationScheme)
                .AddAzureADBearer(options => Configuration.Bind("AzureActiveDirectory", options));

            services.Configure<JwtBearerOptions>(AzureADDefaults.JwtBearerAuthenticationScheme, options =>
            {
                options.Events = new JwtBearerEvents
                {
                    OnTokenValidated = async ctxt =>
                    {

                        var authUser = ctxt.HttpContext.RequestServices.GetRequiredService<ILoggedInUserService>();
                        if (authUser.User.IsAdmin)
                        {
                            var claims = new List<Claim>
                                {
                                    new Claim(ClaimTypes.Role, "admin")
                                };
                            var appIdentity = new ClaimsIdentity(claims);

                            ctxt.Principal.AddIdentity(appIdentity);
                        }

                        await Task.Yield();
                    },
                    OnMessageReceived = context =>
                    {
                        var accessToken = context.Request.Query["access_token"];
                        var path = context.HttpContext.Request.Path;
                        if (!string.IsNullOrEmpty(accessToken) && path.StartsWithSegments("/signalr/projectnotification"))
                        {
                            context.Token = accessToken;
                        }
                        return Task.CompletedTask;
                    }
                };
            });




            services.AddCors(options => options.AddPolicy("AppCORSPolicy", p => p.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CF API", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement{
                    {
                        new OpenApiSecurityScheme
        {
            Reference = new OpenApiReference
            {
                Type = ReferenceType.SecurityScheme,
                Id = "Bearer"
            },
            Scheme = "oauth2",
            Name = "Bearer",
            In = ParameterLocation.Header,

        },
        new List<string>() }
                });
            });
            

            services.AddHttpContextAccessor();
            services.AddApplication();
            services.AddInfrastructure(Configuration);

            services.AddControllers().AddNewtonsoftJson();

            services.AddScoped<ILoggedInUserService, LoggedInUserService>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddMediatR(Assembly.GetExecutingAssembly());
            //services.AddScoped<IReceiveUserBus, ReceiveUserBus>();


            services.AddMediatR(typeof(CreateUserCommandHandler).GetTypeInfo().Assembly);
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IMapper, Mapper>();
            services.AddSingleton<IReceiveUserBus, ReceiveUserBus>();

            // IReceiveUserBus.ReceiveMessageAsync().GetAwaiter().GetResult();
            //ReceiveUserBus receiveUserBus = new ReceiveUserBus( _httpContextAccessor);
            // receiveUserBus.ReceiveMessageAsync().GetAwaiter().GetResult();
            // Application.Services.Implementations.ReceiveUserAddedBus.ReceiveMessageAsync().GetAwaiter().GetResult();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("AppCORSPolicy");
            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();



            #region Swagger
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "CFConceptBrain");
            });
            #endregion

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            var bus = app.ApplicationServices.GetService<IReceiveUserBus>();
            bus.ReceiveMessageAsync().GetAwaiter().GetResult();
        }
    }
}
