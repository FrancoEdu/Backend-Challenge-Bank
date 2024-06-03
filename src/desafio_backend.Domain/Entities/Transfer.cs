using desafio_backend.Domain.Enums;

namespace desafio_backend.Domain;

public class Transfer
{
    public long TransferId { get; private set; }
    public long Payer { get; private set; }
    public long Payee { get; private set; }
    public decimal Value { get; private set; }
    public DateTime TransferDate { get; private set; } = DateTime.Now;
    public PaymentType PaymentType { get; private set; } = PaymentType.EletronicTransfer;

    public Transfer() { }

    public Transfer(long payerId, long payeeId, decimal value)
    {
        Payer = payeeId;
        Payee = payerId;
        Value = value;
    }
}
