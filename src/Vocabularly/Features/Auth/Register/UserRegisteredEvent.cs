using MediatR;

namespace Vocabularly.Features.Auth.Register
{
    public sealed record UserRegisteredEvent(Guid UserId, string Email) : INotification;
}
