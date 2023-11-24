using BackEnd_ApiTech.Shared.Persistence.Contexts;
using BackEnd_ApiTech.Shared.Persistence.Repositories;
using BackEnd_ApiTech.TechXPrime.Domain.Models;
using BackEnd_ApiTech.TechXPrime.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BackEnd_ApiTech.TechXPrime.Persistence.Repositories;

public class RequestsRepository : BaseRepository, IRequestRepository
{
    public RequestsRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Request>> ListAsync()
    {
        return await _context.Requests.ToListAsync();
    }

    public async Task AddAsync(Request order)
    {
        await _context.Requests.AddAsync(order);
    }

    public async Task<Request> FindByIdAsync(int id)
    {
        return await _context.Requests.FindAsync(id);
    }

    public async Task<IEnumerable<Request>> ListByTechnicalIdAsync(int technicalId)
    {
        return await _context.Requests
            .Where(p => p.TechnicalId == technicalId)
            .ToListAsync();
    }

    public void Remove(Request order)
    {
        _context.Requests.Remove(order);
    }
}