using RepositoryContracts.SarInfo;
using System.Collections.Generic;
using System.Linq;
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
        public List<ClosureCriterions> GetAll()
        {
            return _repository.FindAll().ToList();
        }
    }
}
