using System.Threading.Tasks;
using TNA.DataDefinitionObjects;

namespace RepositoryContracts.PreparedFile
{
    public interface IPreparedFileContext
    {
        Task<PrepFile> GetAsync(string iaid);

        Task<bool> UpsertAsync(PrepFile preparedFile);

        Task<bool> DeleteAsync(string iaid);
    }
}
