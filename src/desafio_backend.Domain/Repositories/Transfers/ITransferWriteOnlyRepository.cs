namespace desafio_backend.Domain.Repositories.Transfers;
public interface ITransferWriteOnlyRepository
{
    Task Add(Transfer transfer);
}
