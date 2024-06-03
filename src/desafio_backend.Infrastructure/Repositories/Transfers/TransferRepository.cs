using desafio_backend.Domain;
using desafio_backend.Domain.Repositories.Transfers;

namespace desafio_backend.Infrastructure.Repositories.Transfers;
public class TransferRepository : ITransferWriteOnlyRepository
{
    private readonly DesafioDbContext _dbContext;
    public TransferRepository(DesafioDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Add(Transfer transfer)
    {
        await _dbContext.Transfer.AddAsync(transfer);
    }
}
