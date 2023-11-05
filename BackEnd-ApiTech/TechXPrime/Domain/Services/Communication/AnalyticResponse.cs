using BackEnd_ApiTech.Shared.Domain.Services.Communication;
using BackEnd_ApiTech.TechXPrime.Domain.Models;

namespace BackEnd_ApiTech.TechXPrime.Domain.Services.Communication;

public class AnalyticResponse : BaseResponse<Analytic>
{
    public AnalyticResponse(string message) : base(message)
    {
    }

    public AnalyticResponse(Analytic resource) : base(resource)
    {
    }
}