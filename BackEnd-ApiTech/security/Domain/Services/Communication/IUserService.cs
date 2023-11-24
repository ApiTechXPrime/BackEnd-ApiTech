using BackEnd_ApiTech.security.Domain.Models;
using BackEnd_ApiTech.security.Services.Communication;

namespace BackEnd_ApiTech.security.Domain.Services.Communication;

public interface IUserService
{
    Task<AuthenticateResponse> Authenticate(AuthenticateRequest request);
    Task<IEnumerable<User>> ListAsync();
    Task<User> GetByIdAsync(int id);
    Task RegisterAsync(RegisterRequest model);
    Task UpdateAsync(int id, UpdateRequest model);
    Task DeleteAsync(int id);
}