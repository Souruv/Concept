
using CF.ConceptBrainService.Api.Services;
using CF.ConceptBrainService.Application.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CF.ConceptBrainService.Api
{
    public class Program
    {
        

        public static void Main(string[] args)
        {
            

            //var host = CreateHostBuilder(args).Build();

            //using (var scope = host.Services.CreateScope())
            //{
            //    var services = scope.ServiceProvider;
            //    try
            //    {
            //        ReceiveMessageAsync()
            //        var httpContext = services.GetRequiredService<IHttpContextAccessor>();

            //        var repository = services.GetRequiredService<IReceiveUserBus>();
            //        repository.ReceiveMessageAsync().GetAwaiter().GetResult();
            //    }
            //    catch (Exception ex)
            //    {
            //        var logger = services.GetRequiredService<ILogger<Program>>();
            //        logger.LogError(ex, "An error occurred while seeding the database.");
            //    }
            //}
            //host.Run();


            // Application.Services.Implementations.ReceiveUserAddedBus.ReceiveMessageAsync().GetAwaiter().GetResult();
            CreateHostBuilder(args).Build().Run();
           
        }

         static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });



    }
}
