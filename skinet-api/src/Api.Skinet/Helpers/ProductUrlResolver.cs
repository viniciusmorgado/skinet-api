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
            //TODO: Check why the appsettings.development.json config are completely ignore.
            return configuration["ApiUrl"] + source.Picture;
        }

        return null;
    }
}
