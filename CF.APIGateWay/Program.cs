using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CF.APIGateWay
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                }).ConfigureAppConfiguration((context, config) =>
                {

                    config.AddJsonFile("ocelot."+ context.HostingEnvironment.EnvironmentName + ".json", optional: false, reloadOnChange: true);

                    //if (context.HostingEnvironment.IsEnvironment("Development"))
                    //{
                    //    config.AddJsonFile("ocelot.Development.json", optional: false, reloadOnChange: true);
                    //}
                    //else
                    //{
                    //    config.AddJsonFile("ocelot.Localhost.json", optional: false, reloadOnChange: true);
                    //}

                });
    }
}
