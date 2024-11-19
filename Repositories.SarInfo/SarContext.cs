using MongoDB.Driver;
using RepositoryContracts.SarInfo;
using System;
using System.Threading.Tasks;
using TNA.DataDefinitionObjects;
using TNA.RepositoryLibraries.MongoDB;

namespace Repositories.SarInfo
{
    public class SarContext : ISarContext
    {
        private readonly IRepository<Sar> _repository;

        public SarContext(IRepository<Sar> repository)
        {
            _repository = repository;
        }
        public async Task<bool> DeleteAsync(string iaid)
        {
            return await _repository.DeleteAsync(r => r.RelatedToIA == iaid);
        }

        public async Task<Sar> GetAsync(string iaid)
        {
            var filter = _repository.FilterDefinition.Eq(r => r.RelatedToIA, iaid);

            return await _repository.FirstAsync(filter, null);
        }

        public async Task<bool> UpsertAsync(Sar sar)
        {
            return await _repository.ReplaceAsync(r => r.RelatedToIA == sar.RelatedToIA, sar, new UpdateOptions { IsUpsert = true });
        }
    }
}
