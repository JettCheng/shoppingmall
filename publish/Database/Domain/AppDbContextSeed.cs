using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Hosting;
using Core.Entities.OrderAggregate;

namespace Infrastructure.Database.Domain
{
    public class AppDbContextSeed
    {
        public static async Task SeedAsync(AppDbContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                var seedsPath  = @"/Database/Domain/Seeds/";
                var currentPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)+ seedsPath;

                if (!context.ProductTypes.Any())
                {
                    var productTypesData = File.ReadAllText(currentPath+ @"productTypes.json");
                    var productTypes = JsonConvert.DeserializeObject<IList<ProductType>>(productTypesData);
                    foreach (var item in productTypes)
                    {
                        context.ProductTypes.Add(item);
                    }
                    await context.SaveChangesAsync();
                } 
                
                if (!context.Products.Any())
                {
                    var productsData = File.ReadAllText(currentPath+ @"products.json");
                    var products = JsonConvert.DeserializeObject<IList<Product>>(productsData);
                    foreach (var item in products)
                    {
                        context.Products.Add(item);
                    }
                    await context.SaveChangesAsync();
                } 

                if (!context.ProductImages.Any())
                {
                    var productImagesData = File.ReadAllText(currentPath+ @"productImages.json");
                    var productImages = JsonConvert.DeserializeObject<IList<ProductImage>>(productImagesData);
                    foreach (var item in productImages)
                    {
                        context.ProductImages.Add(item);
                    }
                    await context.SaveChangesAsync();
                }

                if (!context.DeliveryMethods.Any())
                {
                    var deliveriesData = File.ReadAllText(currentPath+ @"deliveries.json");
                    var deliveryMethods = JsonConvert.DeserializeObject<IList<DeliveryMethod>>(deliveriesData);
                    foreach (var item in deliveryMethods)
                    {
                        context.DeliveryMethods.Add(item);
                    }
                    await context.SaveChangesAsync();
                }
                

                // var productType = new ProductType()
                // {
                //     Id="FA",
                //     Level=0,
                //     ParentId= "",
                //     Name="流行時尚"   
                // };
                // context.ProductTypes.Add(productType);
                // await context.SaveChangesAsync();

                // var productId = Guid.NewGuid();

                // var product = new Product()
                // {
                //     Id=productId,
                //     Title="HTC TOW",
                //     ProductTypeId="FA",
                //     OriginalPrice=3300,
                //     Status=ProductStatus.Remove,
                //     Description="Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.",
                //     CoverImage="http://placekitten.com/g/300/300"
                // };
                // context.Products.Add(product);
                // await context.SaveChangesAsync();

                // var productImage = new ProductImage()
                // {
                //     ProductId=productId,
                //     Status=ProductImageStatus.Using,
                //     Url="http://placekitten.com/g/300/300"
                // };
                // context.ProductImages.Add(productImage);
                // await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<AppDbContext>();
                logger.LogError(ex.Message);
            }
        }
    }
}
