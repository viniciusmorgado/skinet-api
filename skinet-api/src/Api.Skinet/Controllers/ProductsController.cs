using Api.Skinet.Data;
using Domain.Skinet.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Skinet.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController(StoreContext _context) : ControllerBase
{

    [HttpGet]
    public async Task<ActionResult<List<Product>>> GetProducts()
    {
        return await _context.Products.ToListAsync();
    }

    [HttpGet("{id:int}")]
    //[Route("{id:int}")]
    public async Task<ActionResult<Product>> GetProductById(int id)
    {
        return await _context.Products.FindAsync(id);
    }
}
