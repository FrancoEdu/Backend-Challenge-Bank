using desafio_backend.Domain;
using desafio_backend.Domain.Repositories.Users;

namespace desafio_backend.Infrastructure.Repositories.Users;
public class UserRepository : IUserWriteOnlyRepository
{
    private readonly DesafioDbContext _dbContext;

    public UserRepository(DesafioDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Add(User user)
    {
       await _dbContext.User.AddAsync(user);
    }
}
