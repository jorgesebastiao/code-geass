using CodeGeass.IntegrationsEvents;
using Rebus.Handlers;

namespace CodeGeass.KnightmareFrames.Api.IntegrationEvents.Customers
{
    /// <summary>
    /// Handler responsavel por processar evento de criação
    /// </summary>
    public class CharacterCreatedEventHandler : IHandleMessages<CharacterCreatedIntegrationEvent>
    {
        private readonly ILogger<CharacterCreatedEventHandler> _logger;
        /// <summary>
        /// COnstrutor padrão
        /// </summary>
        /// <param name="logger"></param>
        public CharacterCreatedEventHandler(ILogger<CharacterCreatedEventHandler> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Handler padrão
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public async Task Handle(CharacterCreatedIntegrationEvent message)
        {
            _logger.LogInformation($"Character created with ID:{message.CharacterId}");
            _logger.LogInformation($"Character created with Name:{message.Name}");
            _logger.LogInformation($"Character created with NickName:{message.NickName}");
            await Task.CompletedTask;
        }
    }
}
