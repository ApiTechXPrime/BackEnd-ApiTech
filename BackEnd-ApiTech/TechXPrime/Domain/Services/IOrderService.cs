using BackEnd_ApiTech.TechXPrime.Domain.Models;
using BackEnd_ApiTech.TechXPrime.Domain.Services.Communication;

namespace BackEnd_ApiTech.TechXPrime.Domain.Services;

public interface IOrderService
{
    Task<IEnumerable<Order>> ListByTechnicalId(int technicalId);
    Task<OrderResponse> SaveAsync(Order order);
    Task<OrderResponse> UpdateAsync(int id, Order order);
    Task<OrderResponse> DeleteAsync(int id);
    Task<IEnumerable<Order>> ListAsync();
}