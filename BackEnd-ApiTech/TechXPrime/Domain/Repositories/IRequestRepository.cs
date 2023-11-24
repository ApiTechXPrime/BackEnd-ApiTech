using BackEnd_ApiTech.TechXPrime.Domain.Models;

namespace BackEnd_ApiTech.TechXPrime.Domain.Repositories;

public interface IRequestRepository
{
    Task<IEnumerable<Request>> ListAsync();
    Task AddAsync(Request order);
    Task<Request> FindByIdAsync(int id);
    Task<IEnumerable<Request>> ListByTechnicalIdAsync(int technicalId);
    void Remove(Request order);
}