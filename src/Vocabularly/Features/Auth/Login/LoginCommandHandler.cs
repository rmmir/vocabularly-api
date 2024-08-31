using MediatR;

using Vocabularly.DTOs;
using Vocabularly.Interfaces;

namespace Vocabularly.Features.Auth.Login
{
    internal sealed class LoginCommandHandler : IRequestHandler<LoginCommand, AuthenticationResult>
    {
        private readonly IUserService _userService;
        private readonly IJwtTokenService _jwtTokenGenerator;

        public LoginCommandHandler(IUserService userService, IJwtTokenService jwtTokenGenerator)
        {
            _userService = userService;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public async Task<AuthenticationResult> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _userService.ValidateUserAsync(request.Username, request.Password);
            if (user == null)
            {
                return new AuthenticationResult
                {
                    Success = false,
                    Errors = ["Invalid username or password"]
                };
            }

            var token = _jwtTokenGenerator.GenerateToken(user);

            return new AuthenticationResult
            {
                Success = true,
                Token = token
            };
        }
    }
}
