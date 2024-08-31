using MediatR;
using Vocabularly.DTOs;
using Vocabularly.Interfaces;

namespace Vocabularly.Features.Auth.Register
{
    internal sealed class RegisterCommandHandler : IRequestHandler<RegisterCommand, AuthenticationResult>
    {
        private readonly IUserService _userService;
        private readonly IJwtTokenService _jwtTokenService;
        private readonly IMediator _mediator;

        public RegisterCommandHandler(IUserService userService, IJwtTokenService jwtTokenGenerator, IMediator mediator)
        {
            _userService = userService;
            _jwtTokenService = jwtTokenGenerator;
            _mediator = mediator;
        }

        public async Task<AuthenticationResult> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var existingUser = await _userService.GetUserByEmailAsync(request.Email);
            if (existingUser != null)
            {
                return new AuthenticationResult
                {
                    Success = false,
                    Errors = ["Email already in use"]
                };
            }

            var user = await _userService.CreateUserAsync(request.Username, request.Password, request.Email);
            if (user == null)
            {
                return new AuthenticationResult
                {
                    Success = false,
                    Errors = ["User registration failed"]
                };
            }

            var token = _jwtTokenService.GenerateToken(user);

            // Publish the UserRegisteredEvent
            await _mediator.Publish(new UserRegisteredEvent(user.Id, user.Email), cancellationToken);

            return new AuthenticationResult
            {
                Success = true,
                Token = token
            };
        }
    }
}
