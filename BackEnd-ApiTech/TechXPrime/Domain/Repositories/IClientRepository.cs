using BackEnd_ApiTech.TechXPrime.Domain.Models;

namespace BackEnd_ApiTech.TechXPrime.Domain.Repositories;

public interface IClientRepository
{
    Task<IEnumerable<Client>> ListAsync();
    Task AddAsync(Client client);
    Task<Client> FindByIdAsync(int id);
    Task<Client> FindByEmailAsync(string email);
    void Update(Client client);
    void Remove(Client client);
}