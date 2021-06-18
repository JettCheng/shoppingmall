using AutoMapper;
using Core.Entities;
using Infrastructure.Dtos;

namespace API.Profiles
{
    public class ProductImageProfile: Profile
    {
        public ProductImageProfile()
        {
            CreateMap<ProductImage, ProductImageDto>();
        }
    }
}