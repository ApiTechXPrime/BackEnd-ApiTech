using BackEnd_ApiTech.TechXPrime.Domain.Models;
using BackEnd_ApiTech.TechXPrime.Domain.Services.Communication;

namespace BackEnd_ApiTech.TechXPrime.Domain.Services;

public interface IClientService
{
    Task<ClientResponse> SaveAsync(Client client);
    Task<ClientResponse> UpdateAsync(int id, Client client);
    Task<ClientResponse> DeleteAsync(int id);
    Task<IEnumerable<Client>> ListAsync();
    Task<Client> FindByEmailAsync(string email);
}