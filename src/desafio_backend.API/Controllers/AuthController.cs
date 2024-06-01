using desafio_backend.Application.UseCase.Auth;
using desafio_backend.Communication.Requests.Auth;
using desafio_backend.Communication.Response.Error;
using desafio_backend.Communication.Response.Token;
using Microsoft.AspNetCore.Mvc;

namespace desafio_backend.API.Controllers;
[Route("api/auth")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthUseCase _authUseCase;

    public AuthController(IAuthUseCase authUseCase)
    {
        _authUseCase = authUseCase;
    }

    [HttpPost]
    [Route("login")]
    [ProducesResponseType(typeof(TokenResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Login([FromBody] AuthLoginRequest req)
    {
        var res = await _authUseCase.Authenticate(req);
        return Ok(res);
    }
}
