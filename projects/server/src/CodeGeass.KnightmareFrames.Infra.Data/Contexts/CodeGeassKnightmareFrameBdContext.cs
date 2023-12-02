using CodeGeass.Core.DomainObjects;
using CodeGeass.Core.Outbox.Services;
using CodeGeass.Infra.Base;
using CodeGeass.KnightmareFrames.Domain.Features.KnightmareFrames;
using CodeGeass.KnightmareFrames.Infra.Data.Base;
using CodeGeass.KnightmareFrames.Infra.Data.Features.KnightmareFrames;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace CodeGeass.KnightmareFrames.Infra.Data.Contexts
{
    /// <summary>
    /// Classe que representa o contexto do banco de dados da aplicação
    /// </summary>
    public class CodeGeassKnightmareFrameBdContext : DbContextBase<CodeGeassKnightmareFrameBdContext>
    {

        /// <summary>
        /// Contrutor padrão da classe de contexto
        /// </summary>
        /// <param name="options"></param>
        public CodeGeassKnightmareFrameBdContext(DbContextOptions<CodeGeassKnightmareFrameBdContext> options, IMediator mediator, IIntegrationEventMapper eventMapper) : base(options, mediator, eventMapper)
        {

        }

        /// <summary>
        /// Construtor padrão para ser utilizando caso venha ser implementado Migrations
        /// </summary>
        /// <param name="options"></param>
        internal CodeGeassKnightmareFrameBdContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<KnightmareFrame> KnightmareFrames { get; set; }

        /// <summary>
        /// Método que é executado quando o modelo de banco de dados está sendo criado pelo EF.
        /// Útil para realizar configurações
        /// </summary>
        /// <param name="modelBuilder">É o construtor de modelos do EF</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("knightmareFrames");
            modelBuilder.ApplyConfiguration(new KnightmareFrameEntityConfiguration());
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
