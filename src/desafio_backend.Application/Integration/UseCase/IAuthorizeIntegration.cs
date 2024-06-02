using desafio_backend.Communication.Response.Integration;

namespace desafio_backend.Application.Integration.UseCase;
public interface IAuthorizeIntegration
{
    Task<AuthorizeMockResponse> AuthorizeTransfer();
}
