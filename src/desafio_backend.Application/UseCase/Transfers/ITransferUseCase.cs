using desafio_backend.Communication.Requests.Transfers;
using desafio_backend.Communication.Response.Transfer;

namespace desafio_backend.Application.UseCase.Transfers;
public interface ITransferUseCase
{
    Task<TransferResponse> Execute(TransferRequest transfer, long payerId);
}
