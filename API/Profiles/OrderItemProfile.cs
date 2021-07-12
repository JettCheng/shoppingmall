using API.Dtos;
using AutoMapper;
using Core.Entities.OrderAggregate;

namespace API.Profiles
{
    public class OrderItemProfile: Profile
    {
        public OrderItemProfile()
        {
            CreateMap<OrderItem, OrderItemDto>();
                // .ForMember(d => d.ProductId, o => o.MapFrom(s => s.ItemOrdered.ProductitemId))
                // .ForMember(d => d.ProductTitle, o => o.MapFrom(s => s.ItemOrdered.ProductTitle))
                // .ForMember(d => d.CoverImage, o => o.MapFrom(s => s.ItemOrdered.CoverImage));
        }
    }
}