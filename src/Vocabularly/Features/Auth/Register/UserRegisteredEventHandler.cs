using MediatR;

namespace Vocabularly.Features.Auth.Register
{
    internal sealed class UserRegisteredEventHandler(ILogger<UserRegisteredEventHandler> logger) : INotificationHandler<UserRegisteredEvent>
    {
        private readonly ILogger<UserRegisteredEventHandler> _logger = logger;

        public Task Handle(UserRegisteredEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"User Registered: {notification.Email}");

            return Task.CompletedTask;
        }
    }
}
