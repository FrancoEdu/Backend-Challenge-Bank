using desafio_backend.Communication.Enums;

namespace desafio_backend.Communication.Response.User;
public class UserRegisterResponseJson
{
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string CpnjCpf { get; set; } = string.Empty;
    public AccountType AccountType { get; set; }
    public DateTime CreatedAt { get; set; }
}
