using Vocabularly.Domain;
using Vocabularly.Interfaces;

namespace Vocabularly.Services
{
    public class UserService : IUserService
    {
        public async Task<User> GetUserByIdAsync(string email)
        {
            return await Task.Run(() => new User() { Username = "", Password = ""} );
        }

        public async Task<User> ValidateUserAsync(string username, string password)
        {
            return await Task.Run(() => new User() { Username = "", Password = "" });
        }

        public async Task<User> CreateUserAsync(string username, string password, string email)
        {
            return await Task.Run(() => new User() { Username = "", Password = "" });
        }
    }
}
