using CodeGeass.Characters.Infra.Data.Contexts;
using CodeGeass.Core.Outbox.Services;
using MediatR;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System.Data.Common;

namespace CodeGeass.Characters.Infra.Data.Tests.Base
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

        protected CodeGeassCharacterBdContext CreateContext()
        {
            var serviceProvider = new ServiceCollection()
                         .AddEntityFrameworkSqlite()
                         .BuildServiceProvider();

            Connection = new SqliteConnection("DataSource=:memory:");
            Connection.Open();

            DbContextOptions<CodeGeassCharacterBdContext> dbContextOptions = new DbContextOptionsBuilder<CodeGeassCharacterBdContext>()
                     .UseSqlite(Connection)
                     .UseApplicationServiceProvider(serviceProvider)
            .Options;

            var codeGeassCharacterBdContext = new CodeGeassCharacterBdContext(dbContextOptions, _mediatorFake.Object, __ntegrationEventMapperFake.Object);
            codeGeassCharacterBdContext.Database.EnsureCreated();
            return codeGeassCharacterBdContext;
        }
    }
}
