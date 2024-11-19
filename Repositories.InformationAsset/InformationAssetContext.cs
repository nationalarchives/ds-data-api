using MongoDB.Driver;
using RepositoryContracts.InformationAsset;
using System.Collections.Generic;
using System.Threading.Tasks;
using TNA.DataDefinitionObjects;
using TNA.RepositoryLibraries.MongoDB;

namespace Repositories.InformationAsset
{
    public class InformationAssetContext : IInformationAssetContext
    {
        private readonly IRepository<IA> _repository;

        public InformationAssetContext(IRepository<IA> repository)
        {
            _repository = repository;
        }

        public async Task<bool> DeleteAsync(string iaid)
        {
            return await _repository.DeleteAsync(r => r.IAID == iaid);
        }

        public async Task<IA> GetAsync(string iaid)
        {
            var filter = _repository.FilterDefinition.Eq(r => r.IAID, iaid);

            return await _repository.FirstAsync(filter, null);
        }

        public async Task<IEnumerable<IA>> GetAsyncByRef(string reference)
        {
            var filter = _repository.FilterDefinition.Eq(r => r.Ref, reference);

            return await _repository.FindAsync(filter, null);
        }

        public async Task<IEnumerable<IA>> GetAsyncByRid(string rid)
        {
            var filter = _repository.FilterDefinition.Eq(r => r.RID, rid);

            return await _repository.FindAsync(filter, null);
        }

        public async Task<bool> UpsertAsync(IA record)
        {
            return await _repository.ReplaceAsync(r => r.IAID == record.IAID, record, new UpdateOptions { IsUpsert = true });
        }
    }
}