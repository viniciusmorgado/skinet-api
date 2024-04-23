using Api.Skinet.DTOs;
using AutoMapper;
using Domain.Skinet.Entities;

namespace Api.Skinet.Helpers;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Product, ProductsToReturnDTO>()
            .ForMember(d => d.ProductBrand, o => o.MapFrom(s => s.ProductBrand.Name))
            .ForMember(d => d.ProductType, o => o.MapFrom(s => s.ProductType.Name))
            .ForMember(d => d.Picture, o => o.MapFrom<ProductUrlResolver>());
    }
}
