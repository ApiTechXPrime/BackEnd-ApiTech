using BackEnd_ApiTech.security.Domain.Models;
using BackEnd_ApiTech.security.Domain.Repositories;
using BackEnd_ApiTech.Shared.Persistence.Contexts;
using BackEnd_ApiTech.Shared.Persistence.Repositories;

namespace BackEnd_ApiTech.security.Persistence.Repository;

public class UserRepository:BaseRepository, IUserRepository
{
    public UserRepository(AppDbContext context) : base(context)
    {
        
    }

    public Task<IEnumerable<User>> ListAsync()
    {
        throw new NotImplementedException();
    }

    public Task AddAsync(User user)
    {
        throw new NotImplementedException();
    }

    public Task<User> FindByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<User> FindByUserEmailAsync(string Email)
    {
        throw new NotImplementedException();
    }

    public bool ExistsByUserEmail(string Email)
    {
        throw new NotImplementedException();
    }

    public User FindById(int id)
    {
        throw new NotImplementedException();
    }

    public void Update(User user)
    {
        throw new NotImplementedException();
    }

    public void Remove(User user)
    {
        throw new NotImplementedException();
    }
    
}