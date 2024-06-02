using desafio_backend.Communication.Response.Integration;
using Refit;

namespace desafio_backend.Application.Integration.Refit;
public interface INotifyRefit
{
    [Post("/v1/notify")]
    Task<ApiResponse<NotifyMockErrorResponse>> NotifyTransfer();
}
