using desafio_backend.Communication.Response.Error;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace desafio_backend.API.Controllers;
[Route("api/transfer")]
[ApiController]
public class TransferController : ControllerBase
{
    [HttpGet]
    [Authorize(Roles = "CommonUser")]
    [ProducesResponseType(typeof(object), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    public IActionResult Get()
    {
        return Ok("Ok");
    }
}
