using desafio_backend.Domain;
using Microsoft.EntityFrameworkCore;

namespace desafio_backend.Infrastructure;

public class DesafioDbContext : DbContext
{
    public DesafioDbContext(DbContextOptions<DesafioDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Transfer> Transfer { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DesafioDbContext).Assembly);
    }
}
