using desafio_backend.Domain.Enums;
using desafio_backend.Domain.ResourcesMessages;

namespace desafio_backend.Domain;

public static class AccountTypeExtension
{
  public static string AccountTypeToString(this AccountType accountType){
    return accountType switch
    {
      AccountType.Shopkeeper => ResourceReportGenerateMessage.SHOPKEEPER,
      AccountType.CommonUser => ResourceReportGenerateMessage.COMMON_USER,
      _ => string.Empty
    };
  }
}
