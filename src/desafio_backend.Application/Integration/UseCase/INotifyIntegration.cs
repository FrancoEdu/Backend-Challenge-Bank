using desafio_backend.Communication.Response.Integration;

namespace desafio_backend.Application.Integration.UseCase;
public interface INotifyIntegration
{
    Task<NotifyMockErrorResponse> NotifyTransfer();
}
