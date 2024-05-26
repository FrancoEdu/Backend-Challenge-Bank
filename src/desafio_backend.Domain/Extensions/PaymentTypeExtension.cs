using desafio_backend.Domain.Enums;
using desafio_backend.Domain.ResourcesMessages;

namespace desafio_backend.Domain;

public static class PaymentTypeExtension
{
  public static string PaymentTypeToString(this PaymentType type){
    return type switch
    {
      PaymentType.Cash => ResourceReportGenerateMessage.CASH,
      PaymentType.CreditCard => ResourceReportGenerateMessage.CREDIT_CARD,
      PaymentType.DebitCard => ResourceReportGenerateMessage.DEBIT_CARD,
      PaymentType.EletronicTransfer => ResourceReportGenerateMessage.ELETRONIC_TRANSFER,
      _ => string.Empty
    };
  }
}
