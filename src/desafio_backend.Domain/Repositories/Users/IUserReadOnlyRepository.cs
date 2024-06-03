namespace desafio_backend.Domain.Repositories.Users;
public interface IUserReadOnlyRepository
{
    Task<User?> GetByEmailAsync(string email);
    Task<User?> GetByCpfCnpjAsync(string cpfCnpj);
    Task<User?> GetByIdAsync(long id);
}
