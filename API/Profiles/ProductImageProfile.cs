using System;
using AutoMapper;
using Core.Dtos;
using Core.Entities;
using Infrastructure.Dtos;

namespace API.Profiles
{
    public class ProductImageProfile: Profile
    {
        public ProductImageProfile()
        {
            CreateMap<ProductImage, ProductImageDto>();
            CreateMap<ProductImageForCreationDto, ProductImage>()
                .ForMember(
                    dest => dest.Status,
                    opt => opt.MapFrom(src => ProductImageStatus.Using)
                )       
                .ForMember(
                    dest => dest.CreatedAt,
                    opt => opt.MapFrom(src => DateTime.UtcNow)
                );
        }
    }
}