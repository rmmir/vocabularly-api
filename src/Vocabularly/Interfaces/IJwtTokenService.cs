using Vocabularly.Domain;

namespace Vocabularly.Interfaces
{
    public interface IJwtTokenService
    {
        string GenerateToken(User user);
    }
}
