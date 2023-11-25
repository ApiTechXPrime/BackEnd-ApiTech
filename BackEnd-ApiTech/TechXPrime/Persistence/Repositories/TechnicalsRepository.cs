using BackEnd_ApiTech.Shared.Persistence.Contexts;
using BackEnd_ApiTech.Shared.Persistence.Repositories;
using BackEnd_ApiTech.TechXPrime.Domain.Models;
using BackEnd_ApiTech.TechXPrime.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BackEnd_ApiTech.TechXPrime.Persistence.Repositories;

public class TechnicalsRepository : BaseRepository, ITechnicalRepository
{
    public TechnicalsRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Technical>> ListAsync()
    {
        return await _context.Technicals.ToListAsync();
    }

    public async Task AddAsync(Technical technical)
    {
        await _context.Technicals.AddAsync(technical);
    }

    public async Task<Technical> FindByIdAsync(int id)
    {
        return await _context.Technicals.FindAsync(id);
    }

    public async Task<Technical> FindByEmailAsync(string email)
    {
        return await _context.Technicals.SingleOrDefaultAsync(t => t.Email == email);
    }

    public void Update(Technical technical)
    {
        _context.Technicals.Update(technical);
    }

    public void Remove(Technical technical)
    {
        _context.Technicals.Remove(technical);
    }
}