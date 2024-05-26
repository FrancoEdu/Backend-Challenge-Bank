using Microsoft.EntityFrameworkCore;

namespace desafio_backend.Infrastructure;

public class DesafioDbContext : DbContext
{
  public DesafioDbContext(DbContextOptions options) : base(options) { }
}
