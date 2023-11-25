using BackEnd_ApiTech.Shared.Persistence.Repositories;
using BackEnd_ApiTech.TechXPrime.Domain.Models;
using BackEnd_ApiTech.TechXPrime.Domain.Repositories;
using BackEnd_ApiTech.TechXPrime.Domain.Services;
using BackEnd_ApiTech.TechXPrime.Domain.Services.Communication;

namespace BackEnd_ApiTech.TechXPrime.Services;

public class ClientsService : IClientService
{
    private readonly IClientRepository _clientRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ClientsService(IClientRepository clientRepository, IUnitOfWork unitOfWork)
    {
        _clientRepository = clientRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ClientResponse> SaveAsync(Client client)
    {
        try
        {
            await _clientRepository.AddAsync(client);
            await _unitOfWork.CompleteAsync();
            return new ClientResponse(client);
        }
        catch (Exception e)
        {
            return new ClientResponse($"An error occurred while saving the client: {e.Message}");
        }
    }

    public async Task<ClientResponse> UpdateAsync(int id, Client client)
    {
        var existingClient = await _clientRepository.FindByIdAsync(id);
        if (existingClient == null)
            return new ClientResponse("Client not found");
        existingClient.FullName = client.FullName;
        existingClient.Cellphone = client.Cellphone;
        existingClient.Problem = client.Problem;
        existingClient.Number = client.Number;
        existingClient.Time = client.Time;
        try
        {
            _clientRepository.Update(existingClient);
            await _unitOfWork.CompleteAsync();
            return new ClientResponse(existingClient);
        }
        catch (Exception e)
        {
            return new ClientResponse($"An error occurred while updating the client: {e.Message}");
        }
    }

    public async Task<ClientResponse> DeleteAsync(int id)
    {
        var existingClient = await _clientRepository.FindByIdAsync(id);
        if (existingClient == null)
            return new ClientResponse("Client not found");
        try
        {
            _clientRepository.Remove(existingClient);
            await _unitOfWork.CompleteAsync();
            return new ClientResponse(existingClient);
        }
        catch (Exception e)
        {
            return new ClientResponse($"An error occurred while updating the client: {e.Message}");
        }
    }

    public async Task<IEnumerable<Client>> ListAsync()
    {
        return await _clientRepository.ListAsync();
    }

    public async Task<Client> FindByEmailAsync(string email)
    {
        return await _clientRepository.FindByEmailAsync(email);
    }
}