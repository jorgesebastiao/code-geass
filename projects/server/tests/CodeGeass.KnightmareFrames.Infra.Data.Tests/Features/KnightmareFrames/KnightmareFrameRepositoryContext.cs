using CodeGeass.KnightmareFrames.Domain.Features.KnightmareFrames;
using CodeGeass.KnightmareFrames.Infra.Data.Base;
using CodeGeass.KnightmareFrames.Infra.Data.Contexts;
using CodeGeass.KnightmareFrames.Infra.Data.Tests.Base;
using CodeGeass.Core.Data;
using CodeGeass.SharedKernel.Result;
using Gwtdo;

namespace CodeGeass.KnightmareFrames.Infra.Data.Tests.Features.KnightmareFrames
{
    public class KnightmareFrameRepositoryContext : InfraBaseTest, IFeatureContext, IFeatureContextLifeCycle
    {
        internal CodeGeassKnightmareFrameBdContext DbContext { get; private set; }
        internal IRepository<KnightmareFrame> Repository { get; private set; }
        internal IKnightmareFrameRepository KnightmareFrameRepository;
        internal CodeGeassResult<IQueryable<KnightmareFrame>> Result;

        public void Setup()
        {
            DbContext = CreateContext();
            Repository = new Repository<KnightmareFrame>(DbContext);
        }

        public void TearDown()
        {
            DbContext.Dispose();
            Connection.Dispose();
        }
    }
}
