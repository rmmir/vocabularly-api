using Microsoft.EntityFrameworkCore;

using Vocabularly.Domain;
using Vocabularly.Interfaces;
using Vocabularly.Persistence;

namespace Vocabularly.Services
{
    public class UserService(ApplicationDbContext dbContext) : IUserService
    {
        private readonly ApplicationDbContext _dbContext = dbContext;

        public async Task<User> GetUserByEmailAsync(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                throw new ArgumentException("Email cannot be empty");
            }

            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == email);

            return user;
        }

        public async Task<User> ValidateUserAsync(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                throw new ArgumentException("Username and password cannot be empty");
            }

            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Username == username);
            bool isPasswordValid = BCrypt.Net.BCrypt.Verify(password, user.Password);

            return isPasswordValid ? user : null;
        }

        public async Task<User> CreateUserAsync(string username, string password, string email)
        {
            try
            {
                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(email))
                {
                    throw new ArgumentException("Username, Email and password cannot be empty");
                }

                bool userExists = await _dbContext.Users.AnyAsync(u => u.Username == username || u.Email == email);
                if (userExists)
                {
                    throw new InvalidOperationException("User with the same username or email already exists.");
                }

                var user = new User
                {
                    Username = username,
                    Email = email,
                    Password = BCrypt.Net.BCrypt.HashPassword(password)
                };

                await _dbContext.Users.AddAsync(user);
                await _dbContext.SaveChangesAsync();

                return user;
            }
            catch (Exception ex)
            {
                throw new Exception("Something went wrong while creating the user: ", ex);
            }
        }
    }
}
