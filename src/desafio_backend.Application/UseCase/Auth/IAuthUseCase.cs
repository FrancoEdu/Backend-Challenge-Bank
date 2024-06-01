using desafio_backend.Communication.Requests.Auth;
using desafio_backend.Communication.Response.Token;

namespace desafio_backend.Application.UseCase.Auth;
public interface IAuthUseCase
{
    Task<TokenResponse> Authenticate(AuthLoginRequest request);
}
