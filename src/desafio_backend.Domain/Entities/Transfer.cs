using desafio_backend.Domain.Enums;

namespace desafio_backend.Domain;

public class Transfer(long payer, long payee, decimal value)
{
    public long TransferId { get; private set; }
    public long Payer { get; private set; } = payer;
    public long Payee { get; private set; } = payee;
    public decimal Value { get; private set; } = value;
    public DateTime TransferDate { get; private set; } = DateTime.Now;
    public PaymentType PaymentType { get; private set; } = PaymentType.EletronicTransfer;
    public virtual User PayerUser { get; private set; }
    public virtual User PayeeUser { get; private set; }
}
