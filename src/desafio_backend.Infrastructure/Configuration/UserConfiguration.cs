using desafio_backend.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace desafio_backend.Infrastructure.Configuration;
public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.UserId);
        builder.Property(x => x.Email).IsRequired();
        builder.Property(x => x.AccountType).IsRequired();
        builder.Property(x => x.PasswordHash).IsRequired();
        builder.Property(x => x.PasswordSalt).IsRequired();
        builder.Property(x => x.CpnjCpf).IsRequired();
    }
}
