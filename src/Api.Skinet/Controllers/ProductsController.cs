using Api.Skinet.Controllers.Base;
using Api.Skinet.DTOs;
using Api.Skinet.Errors;
using Api.Skinet.Helpers;
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
    public async Task<ActionResult<Pagination<ProductsToReturnDTO>>> GetProducts([FromQuery] ProductsParamsSpec productParams)
    {
        var spec = new ProductsWithTypesAndBrandsSpec(productParams);
        var countSpec = new ProductsWithFilterForCountSpec(productParams);
        var totalItems = await _productRepository.CountAsync(countSpec);
        var products = await _productRepository.GetEntityListWithSpecsAsync(spec);
        var data = _mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductsToReturnDTO>>(products); 
        
        return Ok(new Pagination<ProductsToReturnDTO>(
            productParams.PageIndex,
            productParams.PageSize,
            totalItems,
            data
        ));
    }

    [HttpGet("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ProductsToReturnDTO>> GetProductById(int id)
    {
        var spec = new ProductsWithTypesAndBrandsSpec(id);
        var product = await _productRepository.GetEntityWithSpecsAsync(spec);

        if (product == null) return NotFound(new ApiResponse(404));

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
