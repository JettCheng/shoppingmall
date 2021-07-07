using System;
using System.Threading.Tasks;
using Core.Entities;
using Infrastructure.Database.Domain;
using Infrastructure.Database.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var loggerFactory = services.GetRequiredService<ILoggerFactory>();
                try 
                {
                    var appDbContext = services.GetRequiredService<AppDbContext>();
                    await appDbContext.Database.MigrateAsync();
                    await AppDbContextSeed.SeedAsync(appDbContext, loggerFactory);
                    
                    var userManager = services.GetRequiredService<UserManager<Customer>>();
                    var appIdentityDbContext = services.GetRequiredService<AppIdentityDbContext>();
                    await appIdentityDbContext.Database.MigrateAsync();
                    await AppIdentityDbContextSeed.SeedAsync(appIdentityDbContext, userManager, loggerFactory);
                }
                catch (Exception ex)
                {
                    var logger = loggerFactory.CreateLogger<Program>();
                    logger.LogError(ex, "An error occurred during  migration");
                }
                host.Run();
            }
            
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
