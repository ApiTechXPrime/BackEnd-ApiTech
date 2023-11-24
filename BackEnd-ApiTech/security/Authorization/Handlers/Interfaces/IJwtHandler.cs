using BackEnd_ApiTech.security.Domain.Models;

namespace BackEnd_ApiTech.security.Authorization.Handlers.Interfaces;

public interface IJwtHandler
{
    public string GenerateToken(User user);
    public int? ValidateToken(string token);
}