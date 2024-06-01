using desafio_backend.Domain;

namespace desafio_backend.Infrastructure;

public class UnitOfWork : IUnitOfWork
{
  private readonly DesafioDbContext _context;
    public UnitOfWork(DesafioDbContext context)
    {
        _context = context;
    }

    public async Task Commit() => await _context.SaveChangesAsync();
}
