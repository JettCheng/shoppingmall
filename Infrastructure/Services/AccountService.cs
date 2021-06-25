using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Core.Enums;
using Core.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure.Services
{
    public class AccountService: IAccountService
    {
        private readonly IConfiguration _config;
        private readonly SymmetricSecurityKey _key;
        private readonly UserManager<Customer> _userManager;
        private readonly SignInManager<Customer> _signInManager;
        public AccountService(IConfiguration config, UserManager<Customer> userManager, SignInManager<Customer> signInManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _config = config;
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Authentication:SecretKey"]));

        }

        public async Task<string> CreateToken(Customer customer)
        {
            // 創建 JWT
            var signingAlgorithm = SecurityAlgorithms.HmacSha256;
            var claims = new List<Claim>();
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, customer.Email));
            // claims.Add( new Claim("myClaim", "myClaim") );

            var roleNames = await _userManager.GetRolesAsync(customer);
            foreach (var roleName in roleNames)
            {
                var roleClaim = new Claim(ClaimTypes.Role, roleName);
                claims.Add(roleClaim);
            }

            var secretByte = Encoding.UTF8.GetBytes(_config["Authentication:SecretKey"]);
            var signingKey = new SymmetricSecurityKey(secretByte);
            var signingCredentials = new SigningCredentials(signingKey, signingAlgorithm);
            var token = new JwtSecurityToken(
                issuer: _config["Authentication:Issuer"],        // 誰發布這個token
                audience: _config["Authentication:Audience"],    // 發布給誰 哪個前端
                claims,
                notBefore: DateTime.UtcNow,                      // 發布時間
                expires: DateTime.UtcNow.AddMinutes(30),             // 有效期 ex: +1day
                signingCredentials
            );

            var tokenStr = new JwtSecurityTokenHandler().WriteToken(token);

            return tokenStr;
        }
    }
}