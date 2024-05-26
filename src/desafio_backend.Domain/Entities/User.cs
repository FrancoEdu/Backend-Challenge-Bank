using desafio_backend.Domain.Enums;

namespace desafio_backend.Domain;

public class User
{
  public long UserId { get; set; } 
  public string Name { get; set; } = string.Empty;
  public string Email { get; set; } = string.Empty;
  public string CpnjCpf { get; set; } = string.Empty;
  public AccountType AccountType { get; set; }
  public decimal Amount { get; set; } 
  public string Password { get; set; } = string.Empty;
  public DateTime CreatedAt { get; set; }
}
