using System.Threading.Tasks;
using TNA.DataDefinitionObjects;

namespace RepositoryContracts.FAInformationAsset
{
    public interface IFaInformationAssetContext
    {
        Task<FileAuthorityIA> GetAsync(string faid);

        Task<bool> UpsertAsync(FileAuthorityIA faRecord);

        Task<bool> DeleteAsync(string faid);
    }
}
