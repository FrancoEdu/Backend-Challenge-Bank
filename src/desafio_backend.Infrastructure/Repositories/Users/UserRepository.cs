using desafio_backend.Domain;
using desafio_backend.Domain.Repositories.Users;
using Microsoft.EntityFrameworkCore;

namespace desafio_backend.Infrastructure.Repositories.Users;
public class UserRepository : IUserWriteOnlyRepository, IUserReadOnlyRepository
{
    private readonly DesafioDbContext _dbContext;

    public UserRepository(DesafioDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Add(User user)
    {
       await _dbContext.Users.AddAsync(user);
    }

    public void UpdateUserAmountValue(User user)
    {
        _dbContext.Users.Update(user);
    }

    public async Task<User?> GetByCpfCnpjAsync(string cpfCnpj)
    {
        return await _dbContext
            .Users
            .AsNoTracking()
            .Where(x => x.CpnjCpf.Equals(cpfCnpj))
            .FirstOrDefaultAsync();
    }

    public async Task<User?> GetByEmailAsync(string email)
    {
        return await _dbContext
            .Users
            .AsNoTracking()
            .Where(x => x.Email.ToLower().Equals(email.ToLower()))
            .FirstOrDefaultAsync();
    }

    public async Task<User?> GetByIdAsync(long id)
    {
        return await _dbContext
            .Users
            .AsNoTracking()
            .Where(x => x.UserId == id)
            .FirstOrDefaultAsync();
    }
}
