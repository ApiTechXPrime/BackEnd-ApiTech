using AutoMapper;
using BackEnd_ApiTech.security.Domain.Models;
using BackEnd_ApiTech.security.Domain.Repositories;
using BackEnd_ApiTech.security.Domain.Services.Communication;
using BackEnd_ApiTech.security.Services.Communication;

namespace BackEnd_ApiTech.security.Services;

public class UserService: IUserService
{
    private readonly IUserRepository _userRepository;
   
    private readonly IMapper _mapper;

    public UserService(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public Task<AuthenticateResponse> Authenticate(AuthenticateRequest model)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<User>> ListAsync()
    {
        throw new NotImplementedException();
    }

    public Task<User> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task RegisterAsync(RegisterRequest model)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(int id, UpdateRequest model)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}