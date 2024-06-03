using desafio_backend.Application.Integration.Refit;
using desafio_backend.Communication.Response.Integration;
using System.Text.Json;

namespace desafio_backend.Application.Integration.UseCase;
public class NotifyIntegration : INotifyIntegration
{
    private readonly INotifyRefit _notifyRefit;

    public NotifyIntegration(INotifyRefit notifyRefit)
    {
        _notifyRefit = notifyRefit;
    }
    public async Task<bool> NotifyTransfer()
    {
        var response = await _notifyRefit.NotifyTransfer();
        return response.IsSuccessStatusCode ? true : false;
    }
}
