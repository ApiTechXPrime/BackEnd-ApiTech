using BackEnd_ApiTech.TechXPrime.Domain.Models;
using BackEnd_ApiTech.TechXPrime.Domain.Services.Communication;

namespace BackEnd_ApiTech.TechXPrime.Domain.Services;

public interface IAnalyticService
{
    Task<IEnumerable<Analytic>> ListByMonthAsync(int month);
    Task<AnalyticResponse> SaveAsync(Analytic analytic);
    Task<AnalyticResponse> UpdateAsync(int id, Analytic analytic);
    Task<AnalyticResponse> DeleteAsync(int id);
    Task<IEnumerable<Analytic>> ListAsync();
}