using AutoMapper;
using BackEnd_ApiTech.security.Authorization.Handlers.Interfaces;
using BackEnd_ApiTech.security.Domain.Models;
using BackEnd_ApiTech.security.Domain.Repositories;
using BackEnd_ApiTech.security.Domain.Services.Communication;
using BackEnd_ApiTech.security.Exceptions;
using BackEnd_ApiTech.security.Services.Communication;
using BackEnd_ApiTech.Shared.Persistence.Repositories;
using BCryptNet = BCrypt.Net.BCrypt;
namespace BackEnd_ApiTech.security.Services;

public class UserService: IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IJwtHandler _jwtHandler;
    private readonly IMapper _mapper;

    public UserService(IUserRepository userRepository, IMapper mapper, IUnitOfWork unitOfWork, IJwtHandler jwtHandler)
    {
        _userRepository = userRepository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _jwtHandler = jwtHandler;
    }

    public async Task<AuthenticateResponse> Authenticate(AuthenticateRequest request)
    {
        var user = await _userRepository.FindByUserEmailAsync(request.Email);
        Console.WriteLine($"Request: {request.Email}, {request.Password}");
        Console.WriteLine($"User: {user.Id}, {user.FullName}, " +
                          $"{user.Birthday}, {user.Email}, {user.PasswordHash}");
 
        // validate
        if (user == null || !BCryptNet.Verify(request.Password, 
                user.PasswordHash))
        {
            Console.WriteLine("Authentication Error");
            throw new AppException("Email or password is incorrect");
        }
 
        Console.WriteLine("Authentication successful. About to generate token");
        // authentication successful
        var response = _mapper.Map<AuthenticateResponse>(user);
        Console.WriteLine($"Response: {response.Id}, {response.FullName}, " +
                          $"{response.Birthday}, {response.Email}");
        response.Token = _jwtHandler.GenerateToken(user);
        Console.WriteLine($"Generated token is {response.Token}");
        return response;

    }

    public async Task<IEnumerable<User>> ListAsync()
    {
        return await _userRepository.ListAsync();
    }

    public async Task<User> GetByIdAsync(int id)
    {
        var user = await _userRepository.FindByIdAsync(id);
        if (user == null) throw new KeyNotFoundException("User not found");
        return user;
    }

    public async Task RegisterAsync(RegisterRequest request)
    {
        // validate
        if (_userRepository.ExistsByUserEmail(request.Email))
            throw new AppException("Email '" + request.Email + "' is already taken");
        // map model to new user object
        var user = _mapper.Map<User>(request);
        // hash password
        user.PasswordHash = BCryptNet.HashPassword(request.Password);
        
        if (!BCryptNet.Verify(request.ConfirmPassword, user.PasswordHash))
        {
            throw new AppException("Confirmed Password is different");
        }
        // save user
        try
        {
            await _userRepository.AddAsync(user);
            await _unitOfWork.CompleteAsync();

        }
        catch (Exception e)
        {
            throw new AppException($"An error occurred while saving the user: {e.Message}");
        }
    }
    
    private User GetById(int id)
    {
        var user = _userRepository.FindById(id);
        if (user == null) throw new KeyNotFoundException("User not found");
        return user;
    }

    public async Task UpdateAsync(int id, UpdateRequest request)
    {
        var user = GetById(id);
        string confirmedPassword;
        // Validate
        if (_userRepository.ExistsByUserEmail(request.Email))
            throw new AppException("Email '" + request.Email + "' is already taken");
        // Hash password if it was entered
        if (!string.IsNullOrEmpty(request.Password))
        {
            user.PasswordHash = BCryptNet.HashPassword(request.Password);
            
        }
        if (!BCryptNet.Verify(request.ConfirmPassword, user.PasswordHash))
        {
            throw new AppException("Confirmed Password is different");
        }
        
        // Copy model to user and save
        _mapper.Map(request, user);
        try
        {
            _userRepository.Update(user);
            await _unitOfWork.CompleteAsync();
            
        }
        catch (Exception e)
        {
            throw new AppException($"An error occurred while updating the user: {e.Message}");
        }
    }

    public async Task DeleteAsync(int id)
    {
        var user = GetById(id);
        try
        {
            _userRepository.Remove(user);
            await _unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            throw new AppException($"An error occurred while deleting the user: {e.Message}");
        }

    }
}