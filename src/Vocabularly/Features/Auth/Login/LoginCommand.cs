﻿using MediatR;

namespace Vocabularly.Features.Auth.Login
{
    public sealed record LoginCommand(string Username, string Password) : IRequest<AuthenticationResult>;

    public class AuthenticationResult
    {
        public string Token { get; set; }

        public bool Success { get; set; }

        public IEnumerable<string> Errors { get; set; }
    }
}
