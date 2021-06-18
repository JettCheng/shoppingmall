using AutoMapper;
using Core.Entities;
using Infrastructure.Dtos;

namespace API.Profiles
{
    public class ProductProfile: Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDto>();
                // .ForMember(
                //     dest => dest.Status,
                //     opt => opt.
                // )
        }
    }
}