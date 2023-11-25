using BackEnd_ApiTech.TechXPrime.Domain.Models;

namespace BackEnd_ApiTech.TechXPrime.Domain.Repositories;

public interface ITechnicalRepository
{
    Task<IEnumerable<Technical>> ListAsync();
    Task AddAsync(Technical technical);
    Task<Technical> FindByIdAsync(int id);
    Task<Technical> FindByEmailAsync(string email);
    void Update(Technical technical);
    void Remove(Technical technical);
}