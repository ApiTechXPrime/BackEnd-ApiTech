using BackEnd_ApiTech.security.Domain.Models;
using BackEnd_ApiTech.security.Domain.Repositories;
using BackEnd_ApiTech.Shared.Persistence.Contexts;
using BackEnd_ApiTech.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BackEnd_ApiTech.security.Persistence.Repository;

public class UserRepository:BaseRepository, IUserRepository
{
    public UserRepository(AppDbContext context) : base(context)
    {
        
    }

    public async Task<IEnumerable<User>> ListAsync()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task AddAsync(User user)
    {
        await _context.Users.AddAsync(user);
    }

    public async Task<User> FindByIdAsync(int id)
    {
        return await _context.Users.FindAsync(id);
    }

    public async Task<User> FindByUserEmailAsync(string email)
    {
        return await _context.Users.SingleOrDefaultAsync(x => x.Email == email);

    }

    public bool ExistsByUserEmail(string email)
    {
        return _context.Users.Any(x => x.Email == email);
    }

    public User FindById(int id)
    {
        return _context.Users.Find(id);
    }

    public void Update(User user)
    {
        _context.Users.Update(user);
    }

    public void Remove(User user)
    {
        _context.Users.Remove(user);
    }
    
}