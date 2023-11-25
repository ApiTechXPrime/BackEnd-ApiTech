using BackEnd_ApiTech.Shared.Domain.Services.Communication;
using BackEnd_ApiTech.TechXPrime.Domain.Models;

namespace BackEnd_ApiTech.TechXPrime.Domain.Services.Communication;

public class ClientResponse : BaseResponse<Client>
{
    public ClientResponse(string message) : base(message)
    {
    }

    public ClientResponse(Client resource) : base(resource)
    {
    }
}