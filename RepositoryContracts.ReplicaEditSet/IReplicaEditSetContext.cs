using System.Collections.Generic;
using System.Threading.Tasks;
using TNA.DataDefinitionObjects;

namespace RepositoryContracts.ReplicaEditSet
{
    public interface IReplicaEditSetContext
    {
        Task<bool> DeleteAsync(string iaid);
        Task<ReplEditSet> GetAsync(string iaid);
        Task<IEnumerable<ReplEditSet>> GetAsync(int pageSize, int pageNumber);
        Task<bool> UpsertAsync(ReplEditSet replicaEditSet);
        Task<long> CountAsync();
    }
}