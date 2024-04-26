using Api.Skinet.Controllers.Base;
using Api.Skinet.Errors;
using Microsoft.AspNetCore.Mvc;

namespace Api.Skinet.Controllers;

[Microsoft.AspNetCore.Components.Route("errors/{code}")]
[ApiExplorerSettings(IgnoreApi = true)]
public class ErrorController : BaseController
{
    public IActionResult Error(int code)
    {
        return new ObjectResult(new ApiResponse(code));
    }
}
