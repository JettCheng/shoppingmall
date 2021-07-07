using System.Threading.Tasks;
using API.Errors;
using Application.Extensions;
using Core.Dtos;
using Core.Entities;
using Core.Enums;
using Core.Interfaces;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace API.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly IAccountService _accountService;
        private readonly UserManager<Customer> _userManager;
        private readonly SignInManager<Customer> _signInManager;
        private readonly IConfiguration _config;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public AccountController(IHttpContextAccessor httpContextAccessor, IAccountService accountService, UserManager<Customer> userManager, SignInManager<Customer> signInManager, IConfiguration config)
        {
            _httpContextAccessor = httpContextAccessor;
            _config = config;
            _signInManager = signInManager;
            _userManager = userManager;
            _accountService = accountService;
        }

        /// <summary>
        /// 用戶登入
        /// </summary>
        /// <param name="loginDto"></param>   
        /// <returns>令牌</returns>   
        [AllowAnonymous] // 允許匿名訪問 using Authorization
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            // 確認有無用戶帳號
            var user = await _userManager.FindByEmailAsync(loginDto.Email);
            if (user == null) return Unauthorized(new ApiResponse(401));

            // 驗證用戶密碼
            var loginResult = await _signInManager.PasswordSignInAsync(
                user.UserName,
                loginDto.Password,
                false,
                false
            );
            if (!loginResult.Succeeded) return Unauthorized(new ApiResponse(401));

            var newAccessToken = await _accountService.CreateToken(user);
            // var newRefreshToken = await _userManager.GenerateUserTokenAsync(user,  _config["Authentication:Issuer"], "RefreshToken");
            // await _userManager.SetAuthenticationTokenAsync(user, _userManager.Options.Tokens.EmailConfirmationTokenProvider, "RefreshToken", newRefreshToken);


            // Create CustomerDto included token
            var CustomerDtoToReturn = new CustomerDto
            {
                Email = user.Email,
                AccessToken = newAccessToken,
                Name = user.UserName
            };

            // return 200 ok + JWT 
            return Ok(new ApiResponseWithData<CustomerDto>(200, CustomerDtoToReturn));
        }


        /// <summary>
        /// 新用戶註冊
        /// </summary>
        /// <param name="registerDto"></param>   
        /// <returns>註冊資訊</returns>   
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            // 1 使用用戶名創建用戶對象
            var user = new Customer()
            {
                UserName = registerDto.Name,
                Email = registerDto.Email
            };

            // 2 hash密碼，保存用戶
            var result = await _userManager.CreateAsync(user, registerDto.Password);
            if (!result.Succeeded)
            {
                return BadRequest();
            }

            // 3 return
            return Ok(new ApiResponseWithData<RegisterDto>(200, registerDto, "已成功註冊"));
        }

        /// <summary>
        /// 取得當前用戶資訊
        /// </summary>  
        /// <returns>當前用戶資訊與新令牌</returns>  
        [HttpGet]
        [Authorize]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> GetCurrentCustomer()
        {
            var user = _httpContextAccessor.HttpContext.User;
            var customer = await _userManager.FindByEmailFromClaimsPrinciple(user);
            var CustomerDtoToReturn = new CustomerDto 
            {
                Email = customer.Email,
                AccessToken = await _accountService.CreateToken(customer),
                Name = customer.UserName
            };
            return Ok( new ApiResponseWithData<CustomerDto>(200, CustomerDtoToReturn));
        }
    }
}