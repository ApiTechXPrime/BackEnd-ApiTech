using BackEnd_ApiTech.TechXPrime.Domain.Models;
using BackEnd_ApiTech.TechXPrime.Domain.Services.Communication;

namespace BackEnd_ApiTech.TechXPrime.Domain.Services;

public interface ITechnicalService
{
    Task<IEnumerable<Technical>> ListAsync();
    Task<Technical> FindByEmail(string email);
    Task<TechnicalResponse> SaveAsync(Technical technical);
    Task<TechnicalResponse> UpdateAsync(int id, Technical technical);
    Task<TechnicalResponse> DeleteAsync(int id);
}