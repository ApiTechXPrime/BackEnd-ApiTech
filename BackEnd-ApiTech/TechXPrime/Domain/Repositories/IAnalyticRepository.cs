using BackEnd_ApiTech.TechXPrime.Domain.Models;

namespace BackEnd_ApiTech.TechXPrime.Domain.Repositories;

public interface IAnalyticRepository
{
    Task AddAsync(Analytic analytic);
    Task<Analytic> FindByIdAsync(int id);
    Task<IEnumerable<Analytic>> ListByMonthAsync(int month);
    void Update(Analytic analytic);
    void Remove(Analytic analytic);
}