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
        return Ok(await _productRepository.ListAsync(spec));
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Product>> GetProductById(int id)
    {
        return Ok(await _productRepository.GetByIdAsync(id));
    }

    [HttpGet("brands")]
    public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
    {
        return Ok(await _productBrandRepository.ListAllAsync());
    }

    [HttpGet("types")]
    public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypes()
    {
        return Ok(await _productTypeRepository.ListAllAsync());
    }
}
