using System.Threading.Tasks;
using MongoDB.Driver;
using RepositoryContracts.FAInformationAsset;
using TNA.DataDefinitionObjects;
using TNA.RepositoryLibraries.MongoDB;

namespace Repositories.FAInformationAsset
{
    public class FaInformationAssetContext: IFaInformationAssetContext
    {
        private readonly IRepository<FileAuthorityIA> _repository;

        public FaInformationAssetContext(IRepository<FileAuthorityIA> repository)
        {
            _repository = repository;
        }

        public async Task<FileAuthorityIA> GetAsync(string faid)
        {
            var filter = _repository.FilterDefinition.Eq(r => r.FAID, faid);
            return await _repository.FirstAsync(filter, null);
        }

        public async Task<bool> UpsertAsync(FileAuthorityIA faRecord)
        {
            return await _repository.ReplaceAsync(r => r.FAID == faRecord.FAID, faRecord, new UpdateOptions { IsUpsert = true });
        }

        public async Task<bool> DeleteAsync(string faid)
        {
            return await _repository.DeleteAsync(r => r.FAID == faid);
        }
    }
}
