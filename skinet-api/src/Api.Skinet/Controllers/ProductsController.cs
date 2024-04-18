using Microsoft.AspNetCore.Mvc;

namespace Api.Skinet.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    [HttpGet]
    public string GetProducts()
    {
        return "this will be a list of products";
    }

    [HttpGet("{id:int}")]
    //[Route("{id:int}")]
    public string GetProductById(int id)
    {
        return "this will be a single product";
    }
}
