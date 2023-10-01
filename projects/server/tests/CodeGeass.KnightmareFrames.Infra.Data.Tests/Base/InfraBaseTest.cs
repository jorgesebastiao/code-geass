using CodeGeass.Core.Outbox.Services;
using CodeGeass.KnightmareFrames.Infra.Data.Contexts;
using MediatR;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System.Data.Common;

namespace CodeGeass.KnightmareFrames.Infra.Data.Tests.Base
{
    public abstract class InfraBaseTest
    {
        private readonly Mock<IMediator> _mediatorFake;
        private readonly Mock<IIntegrationEventMapper> __ntegrationEventMapperFake;
        public DbConnection Connection { get; set; }

        public InfraBaseTest()
        {
            _mediatorFake = new Mock<IMediator>();
            __ntegrationEventMapperFake = new Mock<IIntegrationEventMapper>();
        }

        protected CodeGeassKnightmareFrameBdContext CreateContext()
        {
            var serviceProvider = new ServiceCollection()
                         .AddEntityFrameworkSqlite()
                         .BuildServiceProvider();

            Connection = new SqliteConnection("DataSource=:memory:");
            Connection.Open();

            DbContextOptions<CodeGeassKnightmareFrameBdContext> dbContextOptions = new DbContextOptionsBuilder<CodeGeassKnightmareFrameBdContext>()
                     .UseSqlite(Connection)
                     .UseApplicationServiceProvider(serviceProvider)
            .Options;

            var codeGeassKnightmareFrameBdContext = new CodeGeassKnightmareFrameBdContext(dbContextOptions, _mediatorFake.Object, __ntegrationEventMapperFake.Object);
            codeGeassKnightmareFrameBdContext.Database.EnsureCreated();
            return codeGeassKnightmareFrameBdContext;
        }
    }
}
