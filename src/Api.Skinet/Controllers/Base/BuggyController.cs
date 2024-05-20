using Api.Skinet.Controllers.Base;
using Api.Skinet.Data;
using Api.Skinet.Errors;
using Microsoft.AspNetCore.Mvc;

namespace Api.Skinet.Controllers;

// Test-only controller
public class BuggyController(StoreContext context) : BaseController
{
    [HttpGet("not-found")]
    public ActionResult NotFoundRequest()
    {
        var thing = context.Products.Find(42);
        
        if (thing == null)
        {
            return NotFound(new ApiResponse(404));
        }

        return Ok();
    }

    [HttpGet("server-error")]
    public ActionResult ServerErrorRequest()
    {
        var thing = context.Products.Find(42);

        var thingToReturn = thing.ToString();
        
        return Ok();
    }

    [HttpGet("bad-request")]
    public ActionResult GetBadRequest() // ControllerBase already have a bad request
    {
        return BadRequest(new ApiResponse(400));
    }

    [HttpGet("bad-request/{id}")]
    public ActionResult NotFoundRequestById(int id)
    {
        return Ok();
    }
}
