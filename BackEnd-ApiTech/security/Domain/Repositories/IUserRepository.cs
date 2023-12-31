using BackEnd_ApiTech.security.Domain.Models;

namespace BackEnd_ApiTech.security.Domain.Repositories;

public interface IUserRepository
{
    Task<IEnumerable<User>> ListAsync();
    Task AddAsync(User user);
    Task<User> FindByIdAsync(int id);
    Task<User> FindByUserEmailAsync(string email);
    public bool ExistsByUserEmail(string email);
    User FindById(int id);
    void Update(User user);
    void Remove(User user);

}