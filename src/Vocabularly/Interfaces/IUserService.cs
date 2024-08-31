using Vocabularly.Domain;

namespace Vocabularly.Interfaces
{
    public interface IUserService
    {
        Task<User> GetUserByEmailAsync(string email);

        Task<User> ValidateUserAsync(string username, string password);

        Task<User> CreateUserAsync(string username, string password, string email);
    }
}
