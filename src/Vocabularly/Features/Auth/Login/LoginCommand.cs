using MediatR;

using Vocabularly.DTOs;

namespace Vocabularly.Features.Auth.Login
{
    public sealed record LoginCommand(string Username, string Password) : IRequest<AuthenticationResult>;
}
