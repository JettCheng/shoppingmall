using Core.Entities;
using Core.Interfaces;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace API.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepository>();
            // services.AddScoped<IProductImageRepository, ProductImageRepository>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddTransient<IPropertyMappingService, PropertyMappingService>();
            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderService, OrderService>();
            // services.AddScoped<IPaymentService, PaymentService>();
            // services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IBasketRepository, BasketRepository>();
            services.AddScoped<IDeliveryMethodRepository, DeliveryMethodRepository>();
            // services.AddScoped(typeof(IGenericRepository<>), (typeof(GenericRepository<>)));
            
            // Model state 與 自定義驗證有關
            // services.Configure<ApiBehaviorOptions>(options =>
            // {
            //     options.InvalidModelStateResponseFactory = actionContext =>
            //     {
            //         var errors = actionContext.ModelState
            //             .Where(e => e.Value.Errors.Count > 0)
            //             .SelectMany(x => x.Value.Errors)
            //             .Select(x => x.ErrorMessage).ToArray();

            //         var errorResponse = new ApiValidationErrorResponse
            //         {
            //             Errors = errors
            //         };

            //         return new BadRequestObjectResult(errorResponse);
            //     };
            // });

            return services;
        }
    }
}