using BackEnd_ApiTech.Shared.Domain.Services.Communication;
using BackEnd_ApiTech.TechXPrime.Domain.Models;

namespace BackEnd_ApiTech.TechXPrime.Domain.Services.Communication;

public class TechnicalResponse : BaseResponse<Technical>
{
    public TechnicalResponse(string message) : base(message)
    {
    }

    public TechnicalResponse(Technical resource) : base(resource)
    {
    }
}