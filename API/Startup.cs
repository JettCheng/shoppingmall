using System;
using System.IO;
using API.Extensions;
using API.Middleware;
using Application.Extensions;
using AutoMapper;
using Infrastructure.Database.Domain;
using Infrastructure.Database.Identity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using StackExchange.Redis;

namespace API
{
    public class Startup
    {
        private readonly IConfiguration _config;
        public Startup(IConfiguration config)
        {
            _config = config;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddControllers();
            services.AddDbContext<AppIdentityDbContext>(
                option =>
                {
                    option.UseSqlServer(_config["ConnectionStrings:Identity"]);
                }
            );
            services.AddDbContext<AppDbContext>(
                option => option.UseSqlServer(_config["ConnectionStrings:Shop"]) 
            );
            
            services.AddApplicationServices();
            services.AddIdentityServices(_config);
            services.AddSwaggerDocumentation();
            services.AddSingleton<ConnectionMultiplexer>(c => {
                var configuartion = ConfigurationOptions.Parse(_config["ConnectionStrings:Redis"], true);
                return ConnectionMultiplexer.Connect(configuartion);
            });

            // services.AddScoped<IProductRepository, ProductRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseMiddleware<ExceptionMiddleware>();

            // if (env.IsDevelopment())
            // {
                app.UseSwaggerDocumentation();
            // }
            app.UseStaticFiles(); // 
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
                    Path.Combine(Directory.GetCurrentDirectory(), "Content")
                ), RequestPath = "/content"
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapFallbackToController("Index", "Fallback");
            });
        }
    }
}
