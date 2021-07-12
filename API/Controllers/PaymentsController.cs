// using System.Threading.Tasks;
// using Core.Entities;
// using Microsoft.AspNetCore.Authorization;
// using Microsoft.AspNetCore.Mvc;

// namespace API.Controllers
// {
//     public class PaymentsController: BaseApiController
//     {
//         // private readonly IPaymentService _paymentService;
//         // private readonly string _whSecret;
//         // private readonly ILogger<PaymentsController> _logger;
//         // public PaymentsController(IPaymentService paymentService, ILogger<PaymentsController> logger, 
//         //     IConfiguration config)
//         // {
//         //     _logger = logger;
//         //     _paymentService = paymentService;
//         //     _whSecret = config.GetSection("StripeSettings:WhSecret").Value;
//         // }

//         [Authorize]
//         [HttpPost("{basketId}")]
//         public async Task<ActionResult<CustomerBasket>> CreateOrUpdatePaymentIntent(string basketId)
//         {
//             // var basket = await _paymentService.CreateOrUpdatePaymentIntent(basketId);

//             // if (basket == null) return BadRequest(new ApiResponse(400, "Problem with your basket"));

//             // return basket;
//             return Ok("haha");
//         }
//     }
// }