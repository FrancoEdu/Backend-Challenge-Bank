using desafio_backend.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace desafio_backend.Infrastructure.Configuration;
public class TransferConfiguration : IEntityTypeConfiguration<Transfer>
{
    public void Configure(EntityTypeBuilder<Transfer> builder)
    {
        builder.HasKey(x => x.TransferId);
        builder.Property(x => x.Payer).IsRequired();
        builder.Property(x => x.Payee).IsRequired();
        builder.Property(x => x.PaymentType).IsRequired();
        builder.Property(x => x.TransferDate).IsRequired();
        builder.Property(x => x.Value).IsRequired();

        builder.HasOne(x => x.PayerUser)
            .WithMany(x => x.PayerTransfers)
            .HasForeignKey(x => x.Payer)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(x => x.PayeeUser)
            .WithMany(x => x.PayeeTransfers)
            .HasForeignKey(x => x.Payee)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
