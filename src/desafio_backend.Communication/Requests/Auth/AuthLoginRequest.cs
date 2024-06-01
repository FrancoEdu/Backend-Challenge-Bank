namespace desafio_backend.Communication.Requests.Auth;
public class AuthLoginRequest
{
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}
