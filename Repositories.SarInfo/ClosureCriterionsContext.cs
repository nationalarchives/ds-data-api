using RepositoryContracts.SarInfo;
using System.Collections.Generic;
using TNA.DataDefinitionObjects;
using TNA.RepositoryLibraries.MongoDB;

namespace Repositories.SarInfo
{
    public class ClosureCriterionsContext : IClosureCriterionsContext
    {
        private readonly IRepository<ClosureCriterions> _repository;

        public ClosureCriterionsContext(IRepository<ClosureCriterions> repository)
        {
            _repository = repository;
        }
        public IEnumerable<ClosureCriterions> GetAll()
        {
            return _repository.FindAll();
        }
    }
}
