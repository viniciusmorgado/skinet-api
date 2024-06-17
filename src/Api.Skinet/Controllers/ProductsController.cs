using Api.Skinet.Controllers.Base;
using Api.Skinet.DTOs;
using Api.Skinet.Errors;
using AutoMapper;
using Domain.Skinet.Entities;
using Domain.Skinet.Interfaces;
using Domain.Skinet.Specs;
using Microsoft.AspNetCore.Mvc;

namespace Api.Skinet.Controllers;

public class ProductsController( IGenericRepository<Product> _productRepository,
                                 IGenericRepository<ProductBrand> _productBrandRepository,
                                 IGenericRepository<ProductType> _productTypeRepository,
                                 IMapper _mapper ) : BaseController
{
    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<ProductsToReturnDTO>>> GetProducts(string sort, int? brandId, int? typeId)
    {
        var spec = new ProductsWithTypesAndBrandsSpec(sort, brandId, typeId);
        var products = await _productRepository.GetEntityListWithSpecsAsync(spec);

        return Ok(_mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductsToReturnDTO>>(products));
    }

    [HttpGet("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ProductsToReturnDTO>> GetProductById(int id)
    {
        var spec = new ProductsWithTypesAndBrandsSpec(id);
        var product = await _productRepository.GetEntityWithSpecsAsync(spec);

        if(product == null) return NotFound(new ApiResponse(404));
        
        return Ok(_mapper.Map<Product, ProductsToReturnDTO>(product));
    }

    [HttpGet("brands")]
    public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
    {
        return Ok(await _productBrandRepository.GetEntityListAsync());
    }

    [HttpGet("types")]
    public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypes()
    {
        return Ok(await _productTypeRepository.GetEntityListAsync());
    }
}
