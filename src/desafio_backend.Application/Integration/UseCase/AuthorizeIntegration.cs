using desafio_backend.Application.Integration.Refit;

namespace desafio_backend.Application.Integration.UseCase;
public class AuthorizeIntegration : IAuthorizeIntegration
{
    private readonly IAuthorizeRefit _refit;
    public AuthorizeIntegration(IAuthorizeRefit refit)
    {
        _refit = refit;
    }

    public async Task<bool> AuthorizeTransfer()
    {
        var response = await _refit.AuthorizeTransfer();
        return response.IsSuccessStatusCode ? true : false;
    }
}
