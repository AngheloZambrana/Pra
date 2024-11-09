using Entities;

namespace Docker.Services.Interfaces;

public interface IUserService
{
    public Task<User?> GetUserAsync(string userId);
    public Task<User?> GetUserByEmailAsync(string email);
    public Task<IEnumerable<User>> GetUsersAsync();
    public Task<User> AddUserAsync(User user);
    public Task<bool> DeleteUserAsync(User user);
    
}