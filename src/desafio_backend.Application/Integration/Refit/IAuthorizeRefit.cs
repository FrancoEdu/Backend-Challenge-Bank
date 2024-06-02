using desafio_backend.Communication.Response.Integration;
using Refit;

namespace desafio_backend.Application.Integration.Refit;
public interface IAuthorizeRefit
{
    [Get("/v2/authorize")]
    Task<ApiResponse<AuthorizeMockResponse>> AuthorizeTransfer();
}
