using BackEnd_ApiTech.Shared.Persistence.Contexts;
using BackEnd_ApiTech.Shared.Persistence.Repositories;
using BackEnd_ApiTech.TechXPrime.Domain.Models;
using BackEnd_ApiTech.TechXPrime.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BackEnd_ApiTech.TechXPrime.Persistence.Repositories;

public class ClientsRepository : BaseRepository, IClientRepository
{
    public ClientsRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Client>> ListAsync()
    {
        return await _context.Clients.ToListAsync();
    }

    public async Task AddAsync(Client client)
    {
        await _context.Clients.AddAsync(client);
    }

    public async Task<Client> FindByIdAsync(int id)
    {
        return await _context.Clients.FindAsync(id);
    }

    public async Task<Client> FindByEmailAsync(string email)
    {
        return await _context.Clients.SingleOrDefaultAsync(p => p.Email == email);
    }

    public void Update(Client client)
    {
        _context.Clients.Update(client);
    }

    public void Remove(Client client)
    {
        _context.Clients.Remove(client);
    }
}