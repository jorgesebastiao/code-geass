using CodeGeass.Characters.Domain.Features.Characters;
using CodeGeass.Characters.Infra.Data.Base;
using CodeGeass.Characters.Infra.Data.Contexts;
using CodeGeass.Characters.Infra.Data.Tests.Base;
using CodeGeass.Core.Data;
using CodeGeass.SharedKernel.Result;
using Gwtdo;

namespace CodeGeass.Characters.Infra.Data.Tests.Features.Characters
{
    public class CharacterRepositoryContext : InfraBaseTest, IFeatureContext, IFeatureContextLifeCycle
    {
        internal CodeGeassCharacterBdContext DbContext { get; private set; }
        internal IRepository<Character> Repository { get; private set; }
        internal ICharacterRepository CharacterRepository;
        internal CodeGeassResult<IQueryable<Character>> Result;

        public void Setup()
        {
            DbContext = CreateContext();
            Repository = new Repository<Character>(DbContext);
        }

        public void TearDown()
        {
            DbContext.Dispose();
            Connection.Dispose();
        }
    }
}
