using desafio_backend.Application.UseCase.Register;
using desafio_backend.Communication.Requests.User;
using desafio_backend.Communication.Response.Error;
using desafio_backend.Communication.Response.User;
using Microsoft.AspNetCore.Mvc;

namespace desafio_backend.API.Controllers;
[Route("api/user")]
[ApiController]
public class UserController : ControllerBase
{
    
    private readonly IUserRegisterUseCase _userRegisterUseCase;

    public UserController(IUserRegisterUseCase userRegisterUseCase)
    {
        _userRegisterUseCase = userRegisterUseCase;
    }

    [HttpPost]
    [Route("create")]
    [ProducesResponseType(typeof(UserRegisterResponseJson), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Register([FromBody] UserRegisterRequestJson req)
    {
        var response = await _userRegisterUseCase.Execute(req);
        return Ok(response);
    }
}
