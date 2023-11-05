using BackEnd_ApiTech.Shared.Persistence.Contexts;
using BackEnd_ApiTech.Shared.Persistence.Repositories;
using BackEnd_ApiTech.TechXPrime.Domain.Models;
using BackEnd_ApiTech.TechXPrime.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BackEnd_ApiTech.TechXPrime.Persistence.Repositories;

public class AnalyticsRepository : BaseRepository, IAnalyticRepository
{
    public AnalyticsRepository(AppDbContext context) : base(context)
    {
    }

    public async Task AddAsync(Analytic analytic)
    {
        await _context.Analytics.AddAsync(analytic);
    }

    public async Task<Analytic> FindByIdAsync(int id)
    {
        return await _context.Analytics.FindAsync(id);
    }

    public async Task<IEnumerable<Analytic>> ListByMonthAsync(int month)
    {
        return await _context.Analytics
            .Where(p => p.Month == month)
            .ToListAsync();
    }

    public void Update(Analytic analytic)
    {
        _context.Analytics.Update(analytic);
    }

    public void Remove(Analytic analytic)
    {
        _context.Analytics.Remove(analytic);
    }
}