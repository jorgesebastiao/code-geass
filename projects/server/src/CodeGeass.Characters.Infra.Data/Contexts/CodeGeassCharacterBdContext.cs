using CodeGeass.Characters.Domain.Features.Characters;
using CodeGeass.Characters.Infra.Data.Features.Characters;
using CodeGeass.Core.DomainObjects;
using CodeGeass.Core.Outbox.Services;
using CodeGeass.Infra.Base;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace CodeGeass.Characters.Infra.Data.Contexts
{
    /// <summary>
    /// Classe que representa o contexto do banco de dados da aplicação
    /// </summary>
    public class CodeGeassCharacterBdContext : DbContextBase<CodeGeassCharacterBdContext>
    {

        /// <summary>
        /// Contrutor padrão da classe de contexto
        /// </summary>
        /// <param name="options"></param>
        public CodeGeassCharacterBdContext(DbContextOptions<CodeGeassCharacterBdContext> options, IMediator mediator, IIntegrationEventMapper eventMapper) : base(options, mediator, eventMapper)
        {

        }

        /// <summary>
        /// Construtor padrão para ser utilizando caso venha ser implementado Migrations
        /// </summary>
        /// <param name="options"></param>
        internal CodeGeassCharacterBdContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Character> Characters { get; set; }

        /// <summary>
        /// Método que é executado quando o modelo de banco de dados está sendo criado pelo EF.
        /// Útil para realizar configurações
        /// </summary>
        /// <param name="modelBuilder">É o construtor de modelos do EF</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("characters");
            modelBuilder.ApplyConfiguration(new CharacterEntityConfiguration());
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies(false);
            base.OnConfiguring(optionsBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            AddTimestamps();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void AddTimestamps()
        {
            var entities = ChangeTracker.Entries()
                                        .Where(x => x.Entity is Entity && (x.State == EntityState.Added || x.State == EntityState.Modified));

            foreach (EntityEntry entry in entities)
            {
                var currentTime = DateTime.UtcNow;
                Entity entity = (Entity)entry.Entity;
                if (entry.State == EntityState.Added)
                    entity.CreatedAt = currentTime;
                entity.UpdatedAt = currentTime;
            }
        }

    }
}
