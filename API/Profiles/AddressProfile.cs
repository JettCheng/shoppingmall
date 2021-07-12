using AutoMapper;
using API.Dtos;
using Core.Entities.OrderAggregate;
using static Core.Entities.OrderAggregate.Order;

namespace API.Profiles
{
    public class AddressProfile: Profile
    {
        public AddressProfile()
        {
            CreateMap<AddressDto, Address>();
        }
    }
}