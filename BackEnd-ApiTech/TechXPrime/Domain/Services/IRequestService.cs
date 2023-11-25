using BackEnd_ApiTech.TechXPrime.Domain.Models;
using BackEnd_ApiTech.TechXPrime.Domain.Services.Communication;

namespace BackEnd_ApiTech.TechXPrime.Domain.Services;

public interface IRequestService
{
    Task<IEnumerable<Request>> ListByTechnicalId(int technicalId);
    Task<Request> FindById(int id);
    Task<RequestResponse> SaveAsync(Request request);
    Task<RequestResponse> DeleteAsync(int id);
    Task<IEnumerable<Request>> ListAsync();
}