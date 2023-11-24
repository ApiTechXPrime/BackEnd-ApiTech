using BackEnd_ApiTech.Shared.Persistence.Repositories;
using BackEnd_ApiTech.TechXPrime.Domain.Models;
using BackEnd_ApiTech.TechXPrime.Domain.Repositories;
using BackEnd_ApiTech.TechXPrime.Domain.Services;
using BackEnd_ApiTech.TechXPrime.Domain.Services.Communication;

namespace BackEnd_ApiTech.TechXPrime.Services;

public class RequestsService : IRequestService
{
    private readonly IRequestRepository _requestRepository;
    private readonly IUnitOfWork _unitOfWork;

    public RequestsService(IRequestRepository requestRepository, IUnitOfWork unitOfWork)
    {
        _requestRepository = requestRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Request>> ListByTechnicalId(int technicalId)
    {
        return await _requestRepository.ListByTechnicalIdAsync(technicalId);
    }
    
    public async Task<IEnumerable<Request>> ListAsync()
    {
        return await _requestRepository.ListAsync();
    }

    public async Task<RequestResponse> SaveAsync(Request request)
    {
        try
        {
            await _requestRepository.AddAsync(request);
            await _unitOfWork.CompleteAsync();
            return new RequestResponse(request);
        }
        catch (Exception e)
        {
            return new RequestResponse($"An error occurred while saving the request: {e.Message}");
        } 
    }

    public async Task<RequestResponse> DeleteAsync(int id)
    {
        var existingRequest = await _requestRepository.FindByIdAsync(id);
        if(existingRequest == null)
            return new RequestResponse("Request not found.");
        try
        {
            _requestRepository.Remove(existingRequest);
            await _unitOfWork.CompleteAsync();
            return new RequestResponse(existingRequest);
        }
        catch (Exception e)
        {
            return new RequestResponse($"An error occurred while deleting the request: {e.Message}");
        }
    }
}