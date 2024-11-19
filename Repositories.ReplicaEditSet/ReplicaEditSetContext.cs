using MongoDB.Driver;
using RepositoryContracts.ReplicaEditSet;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TNA.DataDefinitionObjects;
using TNA.RepositoryLibraries.MongoDB;

namespace Repositories.ReplicaEditSet
{
    public class ReplicaEditSetContext : IReplicaEditSetContext
    {
        private readonly IRepository<ReplEditSet> _repository;

        public ReplicaEditSetContext(IRepository<ReplEditSet> repository)
        {
            _repository = repository;
        }

        public async Task<ReplEditSet> GetAsync(string iaid)
        {
            Expression<Func<ReplEditSet, bool>> filter = (x => x.Sub == null && x.IAID == iaid);

            return await _repository.FirstAsync(filter, null);
        }

        public async Task<long> CountAsync()
        {
            return await _repository.CountAsync(_ => true);
        }

        public async Task<IEnumerable<ReplEditSet>> GetAsync(int pageSize, int pageNumber)
        {
            Expression<Func<ReplEditSet, bool>> filter = (_ => true);
            var findOptions = _repository.FindOptions;
            findOptions.Skip = (pageSize * (pageNumber - 1));
            findOptions.Limit = pageSize;
            return await _repository.FindAsync(filter, findOptions);
        }

        public async Task<bool> DeleteAsync(string iaid)
        {
            return await _repository.DeleteAsync(x => x.Sub == null && x.IAID == iaid);
        }

        public async Task<bool> UpsertAsync(ReplEditSet replicaEditSet)
        {
            return await _repository.ReplaceAsync(x => x.Sub == null && x.IAID == replicaEditSet.IAID, replicaEditSet, new UpdateOptions { IsUpsert = true });
        }
    }
}