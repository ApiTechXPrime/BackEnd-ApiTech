using BackEnd_ApiTech.Shared.Domain.Services.Communication;
using BackEnd_ApiTech.TechXPrime.Domain.Models;

namespace BackEnd_ApiTech.TechXPrime.Domain.Services.Communication;

public class RequestResponse : BaseResponse<Request>
{
    public RequestResponse(string message) : base(message)
    {
    }

    public RequestResponse(Request resource) : base(resource)
    {
    }
}