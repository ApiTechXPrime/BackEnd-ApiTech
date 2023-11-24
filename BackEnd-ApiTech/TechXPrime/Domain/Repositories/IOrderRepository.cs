using BackEnd_ApiTech.TechXPrime.Domain.Models;

namespace BackEnd_ApiTech.TechXPrime.Domain.Repositories;

public interface IOrderRepository
{
    Task<IEnumerable<Order>> ListAsync();
    Task AddAsync(Order order);
    Task<Order> FindByIdAsync(int id);
    Task<IEnumerable<Order>> ListByTechnicalIdAsync(int technicalId);
    void Update(Order order);
    void Remove(Order order);
}