using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ASPdotNETExample.Data;
using ASPdotNETExample.Models;

using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ASPdotNETExample
{
    public class Program
    {
        public static ILogger<Program> _log;

        public static void Main(string[] args)
        {
            IHost host = CreateHostBuilder(args).Build();

            using IServiceScope scope = host.Services.CreateScope();
            IServiceProvider provider = scope.ServiceProvider;

            _log = provider.GetRequiredService<ILogger<Program>>();

            try
            {
                SeedData.Initialize(provider);
            }
            catch (Exception ex)
            {
                _log.LogError(ex, "An error occured seeding DB.");
            }


            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
