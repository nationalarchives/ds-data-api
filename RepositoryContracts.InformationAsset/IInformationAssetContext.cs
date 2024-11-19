using System.Collections.Generic;
using System.Threading.Tasks;
using TNA.DataDefinitionObjects;

namespace RepositoryContracts.InformationAsset
{
    public interface IInformationAssetContext
    {
        Task<IA> GetAsync(string iaid);
        Task<IEnumerable<IA>> GetAsyncByRef(string reference);

        Task<IEnumerable<IA>> GetAsyncByRid(string rid);

        Task<bool> UpsertAsync(IA record);

        Task<bool> DeleteAsync(string iaid);
    }
}