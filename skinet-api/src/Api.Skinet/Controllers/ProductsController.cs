using Api.Skinet.Data;
using Api.Skinet.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Api.Skinet.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController(StoreContext _context) : ControllerBase
{

    [HttpGet]
    public ActionResult<List<Product>> GetProducts()
    {
        return _context.Products.ToList();
    }

    [HttpGet("{id:int}")]
    //[Route("{id:int}")]
    public string GetProductById(int id)
    {
        return "this will be a single product";
    }
}
