namespace desafio_backend.Domain.Repositories.Users;

public interface IUserWriteOnlyRepository
{
    Task Add(User user);
}
