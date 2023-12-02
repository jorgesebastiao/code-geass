using CodeGeass.Core.Data;
using CodeGeass.Core.DomainObjects;
using CodeGeass.Core.Outbox;
using CodeGeass.Core.Outbox.Services;
using CodeGeass.Infra.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CodeGeass.Infra.Base
{
    public abstract class DbContextBase<TContext> : DbContext, IUnitOfWork where TContext : DbContextBase<TContext>
    {
        private readonly IMediator _mediator;
        public readonly IIntegrationEventMapper EventMapper;

        protected DbContextBase(DbContextOptions options, IMediator mediator, IIntegrationEventMapper eventMapper) : base(options)
        {
            _mediator = mediator;
            EventMapper = eventMapper;
        }

        protected DbContextBase(DbContextOptions options) : base(options)
        {

        }

        public DbSet<OutboxIntegrationEvent> OutboxIntegrationEvents { get; set; }

        public async Task<bool> CommitAsync(CancellationToken cancellationToken)
        {
            await _mediator.DispatchEventsAsync(this);
            await base.SaveChangesAsync(cancellationToken);

            return true;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new OutboxIntegrationEventEntityConfiguration());
            modelBuilder.Ignore<AggregateRoot>();
            modelBuilder.Entity<AggregateRoot>().Ignore(e => e.DomainEvents);
            modelBuilder.Entity<AggregateRoot>().Property(q => q.Id).ValueGeneratedNever();
        }
    }
}
