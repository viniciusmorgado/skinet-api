using Domain.Skinet.Entities;
using Domain.Skinet.Interfaces;
using Domain.Skinet.Specs;
using Microsoft.AspNetCore.Mvc;

namespace Api.Skinet.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController(IGenericRepository<Product> _productRepository,
                                IGenericRepository<ProductBrand> _productBrandRepository,
                                IGenericRepository<ProductType> _productTypeRepository) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<Product>>> GetProducts()
    {
        var spec = new ProductsWithTypesAndBrandsSpec();
        return Ok(await _productRepository.GetEntityListWithSpecsAsync(spec));
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Product>> GetProductById(int id)
    {
        var spec = new ProductsWithTypesAndBrandsSpec(id);
        return Ok(await _productRepository.GetEntityWithSpecsAsync(spec));
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
