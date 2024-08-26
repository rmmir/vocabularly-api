using System.Security.Claims;

namespace Vocabularly.Domain
{
    public class User
    {
        public Guid Id { get; init; } = Guid.NewGuid();

        public string Username { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Role { get; set; }

        public DateTime DateCreated { get; set; } = DateTime.UtcNow;

        public DateTime DateUpdated { get; set; }
    }
}
