using Api.Skinet.DTOs;
using AutoMapper;
using Domain.Skinet.Entities;

namespace Api.Skinet.Helpers;

public class ProductUrlResolver(IConfiguration configuration) : IValueResolver<Product
                                                              , ProductsToReturnDTO, string>
{
    public string Resolve( Product source
                         , ProductsToReturnDTO destination
                         , string destMember
                         , ResolutionContext context )
    {
        if(!string.IsNullOrEmpty(source.Picture))
        {   
            return configuration["ApiUrl"] + source.Picture;
        }

        return null;
    }
}
