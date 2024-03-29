using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarSharing.infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace CarSharing
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var seeder = services.GetRequiredService<BooksContextSeed>();
                await seeder.SeedAllAsync();
            }

            await host.RunAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(ConfigureWebBuilder);

        private static void ConfigureWebBuilder(IWebHostBuilder webBuilder)
        {
            webBuilder.CaptureStartupErrors(true);
            webBuilder.UseDefaultServiceProvider(ConfigureServiceProvider);
            webBuilder.UseUrls("http://0.0.0.0:5000");
            webBuilder.UseStartup<Startup>();
        }

        private static void ConfigureServiceProvider(ServiceProviderOptions serviceProvider)
        {
            serviceProvider.ValidateScopes = true;
            serviceProvider.ValidateOnBuild = true;
        }
    }
}
