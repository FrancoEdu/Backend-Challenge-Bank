using desafio_backend.Communication.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace desafio_backend.Communication.Requests.User;
public class UserRegisterRequestJson
{
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string CpnjCpf { get; set; } = string.Empty;
    public AccountType AccountType { get; set; }
    public string Password { get; set; } = string.Empty;
    public string ConfirmPassword { get; set; } = string.Empty;
}
