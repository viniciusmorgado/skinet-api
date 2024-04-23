using Api.Skinet.DTOs;
using AutoMapper;
using Domain.Skinet.Entities;
using Domain.Skinet.Interfaces;
using Domain.Skinet.Specs;
using Microsoft.AspNetCore.Mvc;

namespace Api.Skinet.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController(IGenericRepository<Product> _productRepository,
                                IGenericRepository<ProductBrand> _productBrandRepository,
                                IGenericRepository<ProductType> _productTypeRepository,
                                IMapper _mapper) : ControllerBase
{
    // Non-automapper DTOs formating
    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<ProductsToReturnDTO>>> GetProducts()
    {
        var spec = new ProductsWithTypesAndBrandsSpec();
        var products = await _productRepository.GetEntityListWithSpecsAsync(spec);

        // return Ok(products.Select(product => new ProductsToReturnDTO
        // {
        //     Id = product.Id,
        //     Name = product.Name,
        //     Description = product.Description,
        //     Picture = product.Picture,
        //     Price = product.Price,
        //     ProductBrand = product.ProductBrand.Name,
        //     ProductType = product.ProductType.Name
        // }).ToList());

        // what if we return using automapper:
        return Ok(_mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductsToReturnDTO>>(products));
    }

    // Automapper DTO formatting
    [HttpGet("{id:int}")]
    public async Task<ActionResult<ProductsToReturnDTO>> GetProductById(int id)
    {
        var spec = new ProductsWithTypesAndBrandsSpec(id);
        var product = await _productRepository.GetEntityWithSpecsAsync(spec);

        // We can only use automapper for those requests that need DTO in the first place
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
