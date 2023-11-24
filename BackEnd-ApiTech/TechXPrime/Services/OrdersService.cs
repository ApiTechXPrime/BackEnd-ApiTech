using BackEnd_ApiTech.Shared.Persistence.Repositories;
using BackEnd_ApiTech.TechXPrime.Domain.Models;
using BackEnd_ApiTech.TechXPrime.Domain.Repositories;
using BackEnd_ApiTech.TechXPrime.Domain.Services;
using BackEnd_ApiTech.TechXPrime.Domain.Services.Communication;

namespace BackEnd_ApiTech.TechXPrime.Services;

public class OrdersService : IOrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly IUnitOfWork _unitOfWork;
    
    public OrdersService(IOrderRepository orderRepository, IUnitOfWork unitOfWork)
    {
        _orderRepository = orderRepository;
        _unitOfWork = unitOfWork;
    }
    
    public async Task<IEnumerable<Order>> ListByTechnicalId(int technicalId)
    {
        return await _orderRepository.ListByTechnicalIdAsync(technicalId);
    }
    
    public async Task<IEnumerable<Order>> ListAsync()
    {
        return await _orderRepository.ListAsync();
    }

    public async Task<OrderResponse> SaveAsync(Order order)
    {
        try
        { 
            await _orderRepository.AddAsync(order);
            await _unitOfWork.CompleteAsync();
            return new OrderResponse(order);
        }
        catch (Exception e)
        {
            return new OrderResponse($"An error occurred while saving the order: {e.Message}");
        }
    }

    public async Task<OrderResponse> UpdateAsync(int id, Order order)
    {
        var existingOrder = await _orderRepository.FindByIdAsync(id);
        if(existingOrder == null)
            return new OrderResponse("Order not found.");
        existingOrder.ValueProgress = order.ValueProgress;
        existingOrder.Finished = order.Finished;
        try
        {
            _orderRepository.Update(existingOrder);
            await _unitOfWork.CompleteAsync();
            return new OrderResponse(existingOrder);
        }
        catch (Exception e)
        {
            return new OrderResponse($"An error occurred while updating the order: {e.Message}");
        }
    }

    public async Task<OrderResponse> DeleteAsync(int id)
    {
        var existingOrder = await _orderRepository.FindByIdAsync(id);
        if(existingOrder == null)
            return new OrderResponse("Order not found.");
        try
        {
            _orderRepository.Remove(existingOrder);
            await _unitOfWork.CompleteAsync();
            return new OrderResponse(existingOrder);
        }
        catch (Exception e)
        {
            return new OrderResponse($"An error occurred while deleting the order: {e.Message}");
        }
    }
}