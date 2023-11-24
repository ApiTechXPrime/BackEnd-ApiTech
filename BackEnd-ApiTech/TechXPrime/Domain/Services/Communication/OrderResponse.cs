using BackEnd_ApiTech.Shared.Domain.Services.Communication;
using BackEnd_ApiTech.TechXPrime.Domain.Models;

namespace BackEnd_ApiTech.TechXPrime.Domain.Services.Communication;

public class OrderResponse : BaseResponse<Order>
{
    public OrderResponse(string message) : base(message)
    {
    }

    public OrderResponse(Order resource) : base(resource)
    {
    }
}