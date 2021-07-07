using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;
using Core.Entities;
using Infrastructure.Database.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Infrastructure.Database.Identity
{
    public class AppIdentityDbContextSeed
    {
        public static async Task SeedAsync(AppIdentityDbContext context, UserManager<Customer> userManager, ILoggerFactory loggerFactory)
        {
            try
            {   
                // 添加角色
                var adminRoleId = "308660dc-ae51-480f-824d-7dca6714c3e2";
                    var role= new IdentityRole
                    {
                        Id = adminRoleId, 
                        Name = "Admin",
                        NormalizedName = "Admin".ToUpper()
                    };
                    context.Roles.Add(role);
                    await context.SaveChangesAsync();

                // 添加用户      
                var adminUserId = "90184155-dee0-40c9-bb1e-b5ed07afc04e";
                Customer adminUser = new Customer
                {
                    Id = adminUserId,
                    UserName = "admin",
                    NormalizedUserName = "admin".ToUpper(),
                    Email = "admin@mail.com",
                    NormalizedEmail = "admin@mail.com".ToUpper(),
                    TwoFactorEnabled = false,
                    EmailConfirmed = true,
                    PhoneNumber = "0912345678",
                    PhoneNumberConfirmed = false
                };
                await userManager.CreateAsync(adminUser, "1qaz@WSX$");

                // 给用户加入管理員權限
                // 通過使用 linking table：IdentityUserRole
                var userRole = new IdentityUserRole<string>() 
                {
                    RoleId = adminRoleId,
                    UserId = adminUserId
                };
                context.UserRoles.Add(userRole);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<AppDbContext>();
                logger.LogError(ex.Message);
            }
        }
    }
}
