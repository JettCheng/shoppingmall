using System;
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
                
            CreateMap<ProductForCreationDto, Product>()
                .ForMember(
                    dest => dest.Status,
                    opt => opt.MapFrom(src => ProductStatus.Using)
                )                
                .ForMember(
                    dest => dest.Id,
                    opt => opt.MapFrom(src => Guid.NewGuid())
                );

            CreateMap<ProductForUpdateDto, Product>()
                .ForMember(
                    dest => dest.Status,
                    opt => opt.MapFrom(src => src.Status.ToString())
                )
                .ForMember(
                    dest => dest.UpdatedAt,
                    opt => opt.MapFrom(src => DateTime.UtcNow)
                );
                // .ForMember(
                //     dest => dest.UpdatedBy,
                //     opt => opt.MapFrom(src => DateTime.UtcNow)
                // );
        }
    }
}