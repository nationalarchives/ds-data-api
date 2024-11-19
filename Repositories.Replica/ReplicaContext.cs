using MongoDB.Driver;
using RepositoryContracts.Replica;
using System.Collections.Generic;
using System.Threading.Tasks;
using TNA.DataDefinitionObjects;
using TNA.RepositoryLibraries.MongoDB;

namespace Repositories.Replica
{
    public class ReplicaContext : IReplicaContext
    {
        private readonly IRepository<Repl> _repository;

        public ReplicaContext(IRepository<Repl> repository)
        {
            _repository = repository;
        }

        public async Task<bool> DeleteAsync(string replicaId)
        {
            return await _repository.DeleteAsync(r => r.RID == replicaId);
        }

        public async Task<Repl> GetAsync(string replicaId)
        {
            var filter = _repository.FilterDefinition.Eq(r => r.RID, replicaId);

            return await _repository.FirstAsync(filter, null);
        }

        public IEnumerable<Repl> Get()
        {
            return _repository.FindAll(0, 50);
        }

        public async Task<bool> UpsertAsync(Repl replica)
        {
            return await _repository.ReplaceAsync(r => r.RID == replica.RID, replica, new UpdateOptions { IsUpsert = true });
        }
    }
}