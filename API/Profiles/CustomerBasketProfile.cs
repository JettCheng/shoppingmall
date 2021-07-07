using Core.Dtos;
using AutoMapper;
using Core.Entities;

namespace API.Profiles
{
    public class CustomerBasketProfile: Profile
    {
        public CustomerBasketProfile()
        {
            CreateMap<CustomerBasketDto, CustomerBasket>();
        }
    }
}