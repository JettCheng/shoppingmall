using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Core.Entities;
using Infrastructure.Database.Domain;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Infrastructure.Database.Domain
{
    public class AppDbContextSeed
    {
        public static async Task SeedAsync(AppDbContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                var seedsPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)+ @"/Database/Domain/Seeds/";

                if (!context.Products.Any())
                {
                    var productsData = File.ReadAllText(seedsPath+ @"products.json");
                    var products = JsonConvert.DeserializeObject<IList<Product>>(productsData);
                    foreach (var item in products)
                    {
                        context.Products.Add(item);
                    }
                    await context.SaveChangesAsync();
                } 

                if (!context.ProductTypes.Any())
                {
                    var productTypesData = File.ReadAllText(seedsPath+ @"productTypes.json");
                    var productTypes = JsonConvert.DeserializeObject<IList<ProductType>>(productTypesData);
                    foreach (var item in productTypes)
                    {
                        context.ProductTypes.Add(item);
                    }
                    await context.SaveChangesAsync();
                } 
                
                if (!context.ProductImages.Any())
                {
                    var productImagesData = File.ReadAllText(seedsPath+ @"productTypes.json");
                    var productImages = JsonConvert.DeserializeObject<IList<ProductImage>>(productImagesData);
                    foreach (var item in productImages)
                    {
                        context.ProductImages.Add(item);
                    }
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<AppDbContext>();
                logger.LogError(ex.Message);
            }
        }
    }
}
