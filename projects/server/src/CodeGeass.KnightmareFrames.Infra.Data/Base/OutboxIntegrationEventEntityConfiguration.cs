using CodeGeass.Core.Outbox;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CodeGeass.KnightmareFrames.Infra.Data.Base
{
    public class OutboxIntegrationEventEntityConfiguration : IEntityTypeConfiguration<OutboxIntegrationEvent>
    {
        public void Configure(EntityTypeBuilder<OutboxIntegrationEvent> builder)
        {
            builder.ToTable("OutboxIntegrationEvents");

        }
    }
}
