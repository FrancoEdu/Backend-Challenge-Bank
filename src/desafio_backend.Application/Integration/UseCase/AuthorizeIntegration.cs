using desafio_backend.Application.Integration.Refit;
using desafio_backend.Communication.Response.Integration;
using System.Text.Json;

namespace desafio_backend.Application.Integration.UseCase;
public class AuthorizeIntegration : IAuthorizeIntegration
{
    private readonly IAuthorizeRefit _refit;
    public AuthorizeIntegration(IAuthorizeRefit refit)
    {
        _refit = refit;
    }

    public async Task<AuthorizeMockResponse> AuthorizeTransfer()
    {
        var response = await _refit.AuthorizeTransfer();
        if (!response.IsSuccessStatusCode)
        {
            var res = JsonSerializer.Deserialize<AuthorizeMockResponse>(response.Error.Content!);
            return res!;
        }

        return response.Content!;
    }
}
