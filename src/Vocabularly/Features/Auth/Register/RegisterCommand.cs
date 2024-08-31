using MediatR;

using Vocabularly.DTOs;

namespace Vocabularly.Features.Auth.Register
{
    public sealed record RegisterCommand(string Username, string Email, string Password) : IRequest<AuthenticationResult>;
}
