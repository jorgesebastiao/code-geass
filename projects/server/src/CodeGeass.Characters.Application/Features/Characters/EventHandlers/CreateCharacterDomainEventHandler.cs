using CodeGeass.Characters.Domain.Features.Characters.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CodeGeass.Characters.Application.Features.Characters.EventHandlers
{
    public class CreateCharacterDomainEventHandler : INotificationHandler<CreateCharacterDomainEvent>
    {
        private readonly ILogger<CreateCharacterDomainEventHandler> _logger;

        public CreateCharacterDomainEventHandler(ILogger<CreateCharacterDomainEventHandler> logger)
        {
            _logger = logger;
        }

        public async Task Handle(CreateCharacterDomainEvent @event, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Character creation domain event with ID:{@event.Character.Id}");
            _logger.LogInformation($"Character creation domain event with Name:{@event.Character.Name}");
            _logger.LogInformation($"Character creation domain event with NickName:{@event.Character.NickName}");
            await Task.CompletedTask;
        }
    }
}
