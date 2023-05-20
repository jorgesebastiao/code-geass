using CodeGeass.Characters.Domain.Features.Characters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CodeGeass.Characters.Infra.Data.Features.Characters
{
    public class CharacterEntityConfiguration : IEntityTypeConfiguration<Character>
    {
        public void Configure(EntityTypeBuilder<Character> builder)
        {
            builder.ToTable("Characters");
            builder.Property(p => p.NickName).HasMaxLength(100).IsRequired();
            builder.Property(p => p.Name).HasMaxLength(100).IsRequired();
        }
    }
}
