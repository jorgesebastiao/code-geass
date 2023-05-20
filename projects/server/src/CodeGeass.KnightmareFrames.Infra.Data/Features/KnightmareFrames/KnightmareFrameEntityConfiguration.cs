using CodeGeass.KnightmareFrames.Domain.Features.KnightmareFrames;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CodeGeass.KnightmareFrames.Infra.Data.Features.KnightmareFrames
{
    public class KnightmareFrameEntityConfiguration : IEntityTypeConfiguration<KnightmareFrame>
    {
        public void Configure(EntityTypeBuilder<KnightmareFrame> builder)
        {
            builder.ToTable("KnightmareFrames");

            builder.Property(p => p.CustomerId).IsRequired();
        }
    }
}
