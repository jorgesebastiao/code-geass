using CodeGeass.Core.Outbox;
using CodeGeass.KnightmareFrames.Infra.Data.Contexts;
using Quartz;
using Rebus.Bus;

namespace CodeGeass.KnightmareFrames.Api.Jobs
{
    /// <summary>
    /// Classe de trabalho responsavel por realizar a publicação dos eventos na fila 
    /// </summary>
    [DisallowConcurrentExecution]
    public class IntegrationEventPublisherJob : IJob
    {
        private readonly IBus _bus;
        private readonly CodeGeassInvoiceBdContext _context;
        private readonly ILogger<IntegrationEventPublisherJob> _logger;

        /// <summary>
        /// Construtor padrão
        /// </summary>
        /// <param name="bus"></param>
        /// <param name="context"></param>
        /// <param name="logger"></param>
        public IntegrationEventPublisherJob(IBus bus, CodeGeassInvoiceBdContext context, ILogger<IntegrationEventPublisherJob> logger)
        {
            _bus = bus;
            _context = context;
            _logger = logger;
        }

        /// <summary>
        /// Metodo responsavel por executar o trabalho de publicação
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task Execute(IJobExecutionContext context)
        {
            _logger.LogInformation("Starting Publishing events from outbox job processing.");

            await PublishOutboxEventsAsync();

            _logger.LogInformation("Finish Publishing events from outbox job processing.");
        }

        private async Task PublishOutboxEventsAsync(CancellationToken stoppingToken = default)
        {
            try
            {
                var integrationEvents = _context.OutboxIntegrationEvents.AsQueryable().ToList();

                if (integrationEvents.Any())
                {
                    _logger.LogInformation("Publishing {count} events from outbox", integrationEvents.Count);

                    foreach (var integrationEvent in integrationEvents)
                    {
                        await PublishIntegrationEventAsync(integrationEvent);
                    }
                    _context.OutboxIntegrationEvents.RemoveRange(integrationEvents);
                    await _context.CommitAsync(stoppingToken);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error publishing outbox events - {ex}", ex.ToString());
            }
        }

        private async Task PublishIntegrationEventAsync(OutboxIntegrationEvent integrationEvent)
        {
            var @event = _context.EventMapper.Factory.Create(integrationEvent);
            await _bus.Publish(@event);
        }
    }
}
