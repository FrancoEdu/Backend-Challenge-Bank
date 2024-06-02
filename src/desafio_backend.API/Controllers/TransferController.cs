using desafio_backend.Application.Integration.UseCase;
using desafio_backend.Communication.Response.Error;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace desafio_backend.API.Controllers;
[Route("api/transfer")]
[ApiController]
public class TransferController : ControllerBase
{
    private readonly IAuthorizeIntegration _authorizeIntegration;
    private readonly INotifyIntegration _notifierIntegration;

    public TransferController(IAuthorizeIntegration authorizeIntegration, INotifyIntegration notifierIntegration)
    {
        _authorizeIntegration = authorizeIntegration;
        _notifierIntegration = notifierIntegration;
    }

    [HttpGet]
    [Authorize(Roles = "CommonUser")]
    [ProducesResponseType(typeof(object), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Get()
    {
        return Ok(await _notifierIntegration.NotifyTransfer());
    }
}
