using Api.Skinet.Data;
using Domain.Skinet.Entities;
using Domain.Skinet.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Skinet.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController(IProductRepository _repository) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<Product>>> GetProducts()
    {
        return Ok(await _repository.GetProductsAsync());
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Product>> GetProductById(int id)
    {
        return Ok(await _repository.GetProductByIdAsync(id));
    }
}
