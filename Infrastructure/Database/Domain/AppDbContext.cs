using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Core.Entities;
using Core.Entities.OrderAggregate;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Infrastructure.Database.Domain
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<DeliveryMethod> DeliveryMethods { get; set; }

        // 準備 seeds
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // string seedsUrl = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)+ "../../../../../Infrastructure/Database/Domain/Seeds/";
            
            // string seedsUrl = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"/Database/Domain/Seeds/";
            // var productsData = File.ReadAllText(seedsUrl+"/products.json");
            // IList<Product> products = JsonConvert.DeserializeObject<IList<Product>>(productsData);
            // modelBuilder.Entity<Product>().HasData(products);

            // var productImagesData = File.ReadAllText(seedsUrl+"productImages.json");
            // IList<ProductImage> productImages = JsonConvert.DeserializeObject<IList<ProductImage>>(productImagesData);
            // modelBuilder.Entity<ProductImage>().HasData(productImages);
            
            // var productTypesData = File.ReadAllText(seedsUrl+"productTypes.json");
            // IList<ProductType> productTypes = JsonConvert.DeserializeObject<IList<ProductType>>(productTypesData);
            // modelBuilder.Entity<ProductType>().HasData(productTypes);
        }
    }
}
