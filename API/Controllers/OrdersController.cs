using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using API.Dtos;
using API.Errors;
using API.Extensions;
using AutoMapper;
using Core.Entities.OrderAggregate;
using Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class OrdersController: BaseApiController
    {        
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;
        public OrdersController(IOrderService orderService, IMapper mapper)
        {
            _mapper = mapper;
            _orderService = orderService;
        }

        [HttpPost]
        public async Task<ActionResult<Order>> CreateOrder(OrderDto orderDto)
        {
            // var email = HttpContext.User.RetrieveEmailFromPrincipal();
            var email = HttpContext.User.FindFirstValue(ClaimTypes.Email);

            // RetrieveEmailFromPrincipal();
            var address = _mapper.Map<Address>(orderDto.ShipToAddress);

            var order = await _orderService.CreateOrderAsync(email, orderDto.DeliveryMethodId, orderDto.BasketId, address);

            if (order == null) return BadRequest(new ApiResponse(400, "訂單建立時出了問題"));

            return Ok(order);
        }

        [HttpGet("deliveryMethods")]
        public async Task<ActionResult<List<DeliveryMethod>>> GetDeliveryMethods()
        {

            var deliveryMethods = await _orderService.GetDeliveryMethodsAsync();
            return Ok(new ApiResponseWithData<List<DeliveryMethod>>(200, deliveryMethods));
        }

        [HttpGet]
        public async Task<ActionResult<List<OrderDto>>> GetOrdersForUser()
        {
            var email = HttpContext.User.FindFirstValue(ClaimTypes.Email);

            var orders = await _orderService.GetOrdersForUserAsync(email);

            var orderToReturnDto = _mapper.Map<List<OrderToReturnDto>>(orders);

            foreach (var item in orderToReturnDto)
            {
                item.Total = orders.FirstOrDefault(o => o.Id == item.Id).GetTotal();
            }

            return Ok(new ApiResponseWithData<List<OrderToReturnDto>>(200, orderToReturnDto));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderToReturnDto>> GetOrderByIdForUser(Guid id)
        {
            var email = User.RetrieveEmailFromPrincipal();

            var order = await _orderService.GetOrderByIdAsync(id, email);

            if (order == null) return NotFound(new ApiResponse(404));

            var OrderToReturnDto = _mapper.Map<OrderToReturnDto>(order);

            // var total = order.Subtotal+order.DeliveryMethod.Price;

            OrderToReturnDto.Total = order.GetTotal();

            return Ok(new ApiResponseWithData<OrderToReturnDto>(200, OrderToReturnDto));
        }
    }
}