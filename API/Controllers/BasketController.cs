using System.Threading.Tasks;
using API.Errors;
using AutoMapper;
using Core.Dtos;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BasketController: BaseApiController
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IMapper _mapper;
        public BasketController(IBasketRepository basketRepository, IMapper mapper)
        {
            _mapper = mapper;
            _basketRepository = basketRepository;
        }
        
        [HttpGet]
        public async Task<ActionResult<CustomerBasket>> GetBasketById(string id)
        {
            var basket = await _basketRepository.GetBasketAsync(id);
            var CustomerBasketForReturn = basket != null ? 
                new ApiResponseWithData<CustomerBasket>(200, basket):
                new ApiResponseWithData<CustomerBasket>(200, new CustomerBasket(id));

            return Ok(CustomerBasketForReturn);

            // ?? → 雙問號左邊若為 null 則值為右邊 
        }

        [HttpPost]
        public async Task<ActionResult<CustomerBasket>> UpdateBasket(CustomerBasketDto basket)
        {
            var customerBasket = _mapper.Map<CustomerBasket>(basket);
 
            var updatedBasket = await _basketRepository.UpdateBasketAsync(customerBasket);

            return Ok(new ApiResponseWithData<CustomerBasket>(200, updatedBasket));
        }

        [HttpDelete]
        public async Task DeleteBasketAsync(string id)
        {
            await _basketRepository.DeleteBasketAsync(id);
        }
    }
}