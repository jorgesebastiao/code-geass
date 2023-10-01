using CodeGeass.Core.Outbox.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGeass.Infra.Tests.Common.Base
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

        protected TContext CreateContext<TContext>()where TContext DbContext
        {
            var serviceProvider = new ServiceCollection()
                         .AddEntityFrameworkSqlite()
                         .BuildServiceProvider();

            Connection = new SqliteConnection("DataSource=:memory:");
            Connection.Open();

            DbContextOptions<TContext> dbContextOptions = new DbContextOptionsBuilder<TContext>()
                     .UseSqlite(Connection)
                     .UseApplicationServiceProvider(serviceProvider)
            .Options;

            var energisaInvoiceBdContext = new EnergisaInvoiceBdContext(dbContextOptions, _mediatorFake.Object, __ntegrationEventMapperFake.Object);
            energisaInvoiceBdContext.Database.EnsureCreated();
            return energisaInvoiceBdContext;
        }
    }
}
