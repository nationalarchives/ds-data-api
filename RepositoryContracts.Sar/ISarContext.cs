using TNA.DataDefinitionObjects;
using System.Threading.Tasks;

namespace RepositoryContracts.SarInfo
{
    public interface ISarContext
    {
        Task<Sar> GetAsync(string iaid);

        Task<bool> UpsertAsync(Sar sar);

        Task<bool> DeleteAsync(string iaid);
    }
}
