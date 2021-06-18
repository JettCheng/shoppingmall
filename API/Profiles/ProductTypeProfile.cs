using AutoMapper;
using Core.Entities;
using Infrastructure.Dtos;

namespace API.Profiles
{
    public class ProductTypeProfile: Profile
    {
        public ProductTypeProfile()
        {
            CreateMap<ProductType, ProductTypeDto>();
        }   
    }
}