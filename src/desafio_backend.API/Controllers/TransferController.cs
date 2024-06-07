using desafio_backend.Application.UseCase.Transfers;
using desafio_backend.Communication.Requests.Transfers;
using desafio_backend.Communication.Response.Error;
using desafio_backend.Communication.Response.Transfer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace desafio_backend.API.Controllers;
[Route("api/transfer")]
[ApiController]
public class TransferController : ControllerBase
{
    private readonly ITransferUseCase _transferUseCase;

    public TransferController(ITransferUseCase transferUseCase)
    {
        _transferUseCase = transferUseCase;
    }

    [HttpPost]
    [Authorize(Roles = "CommonUser")]
    [ProducesResponseType(typeof(TransferResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status503ServiceUnavailable)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> Transfer(TransferRequest transfer)
    {
        var userIdClaim = User.FindFirst(ClaimTypes.Hash)?.Value;
        var response = await _transferUseCase.Execute(transfer, long.Parse(userIdClaim!));
        return Ok(response);
    }
}
