using System.Collections.Generic;
using System.Threading.Tasks;
using TNA.DataDefinitionObjects;

namespace RepositoryContracts.Replica
{
    public interface IReplicaContext
    {
        IEnumerable<Repl> Get();

        Task<Repl> GetAsync(string replicaId);

        Task<bool> UpsertAsync(Repl replica);

        Task<bool> DeleteAsync(string replicaId);
    }
}