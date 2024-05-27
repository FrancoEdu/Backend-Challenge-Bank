using desafio_backend.Domain.Enums;

namespace desafio_backend.Domain;

public class User
{
  public long UserId { get; private set; } 
  public string Name { get; private set; } = string.Empty;
  public string Email { get; private set; } = string.Empty;
  public string CpnjCpf { get; private set; } = string.Empty;
  public AccountType AccountType { get; private set; }
  public decimal Amount { get; private set; } = decimal.Zero;
  public string Password { get; private set; } = string.Empty;
  public DateTime CreatedAt { get; private set; } = DateTime.Now;
}
