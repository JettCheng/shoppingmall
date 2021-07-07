using Core.Dtos;
using AutoMapper;
using Core.Entities;

namespace API.Profiles
{
    public class BasketItemProfile: Profile
    {
        public BasketItemProfile()
        {
            CreateMap<BasketItemDto, BasketItem>();
        }
    }
}