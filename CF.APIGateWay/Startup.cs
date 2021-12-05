using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MMLib.SwaggerForOcelot;
using Microsoft.OpenApi.Models;

namespace CF.APIGateWay
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddCors(options => options.AddPolicy("AppCORSPolicy", p => p.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));
            services.AddCors(options => options.AddPolicy("AppCORSPolicy", p =>
                p.AllowAnyHeader()
                 .AllowAnyMethod()
                 .SetIsOriginAllowed(_ => true)
                 .AllowCredentials()
            ));
            //    services.AddSwaggerGen(c =>
            //    {
            //        c.SwaggerDoc("v1", new OpenApiInfo { Title = "CF API Gateway", Version = "v1" });
            //        c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
            //        {
            //            Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
            //            Name = "Authorization",
            //            In = ParameterLocation.Header,
            //            Type = SecuritySchemeType.ApiKey
            //        });

            //        c.AddSecurityRequirement(new OpenApiSecurityRequirement{
            //            {
            //                new OpenApiSecurityScheme
            //{
            //    Reference = new OpenApiReference
            //    {
            //        Type = ReferenceType.SecurityScheme,
            //        Id = "Bearer"
            //    },
            //    Scheme = "oauth2",
            //    Name = "Bearer",
            //    In = ParameterLocation.Header,

            //},
            //new List<string>() }
            //        });
            //    });


            //services.AddSwaggerForOcelot(Configuration);

            services.AddOcelot();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("AppCORSPolicy");
            app.UseWebSockets();
            app.UseOcelot();//.Wait();
            app.UseRouting();


            //#region Swagger
            //// Enable middleware to serve generated Swagger as a JSON endpoint.
            //app.UseSwagger();

            //// Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            //// specifying the Swagger JSON endpoint.
            //app.UseSwaggerForOcelotUI(Configuration, opt =>
            //{
            //    opt.PathToSwaggerGenerator = "/swagger/docs";
            //}); 
            //app.UseSwaggerUI(c =>
            //{
            //    c.SwaggerEndpoint("/swagger/v1/swagger.json", "CFApiGateway");
            //});
            //#endregion

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });

            });


            //    app.UseSwaggerForOcelotUI(opt =>
            //{
            //    opt.PathToSwaggerGenerator = "/swagger/docs";
            //});
        }
    }
}
