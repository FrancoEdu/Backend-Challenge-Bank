using desafio_backend.Domain.Entities;
using desafio_backend.Domain.Enums;

namespace desafio_backend.Domain.Repositories.Auth;
public interface IAuthRepository
{
    Token GenerateToken(long id, string email, AccountType accountType);
}
