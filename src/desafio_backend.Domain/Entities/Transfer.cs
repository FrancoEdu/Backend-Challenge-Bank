using desafio_backend.Domain.Enums;

namespace desafio_backend.Domain;

public class Transfer
{
  public long TransferId { get; set; }
  public long Payer { get; set; }
  public long Payee { get; set; }
  public decimal Value { get; set; }
  public DateTime TransferDate { get; set; }
  public PaymentType PaymentType { get; set; } 
  public virtual User PayerUser { get; set; }
  public virtual User PayeeUser { get; set; }
}
