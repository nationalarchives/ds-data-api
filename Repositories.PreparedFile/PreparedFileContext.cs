using MongoDB.Driver;
using RepositoryContracts.PreparedFile;
using System.Threading.Tasks;
using TNA.DataDefinitionObjects;
using TNA.RepositoryLibraries.MongoDB;

namespace Repositories.PreparedFile
{
    public class PreparedFileContext : IPreparedFileContext
    {
        private readonly IRepository<PrepFile> _repository;

        public PreparedFileContext(IRepository<PrepFile> repository)
        {
            _repository = repository;
        }

        public async Task<bool> DeleteAsync(string iaid)
        {
            return await _repository.DeleteAsync(r => r.IAID == iaid);
        }

        public async Task<PrepFile> GetAsync(string iaid)
        {
            var filter = _repository.FilterDefinition.Eq(r => r.IAID, iaid);

            return await _repository.FirstAsync(filter, null);
        }

        public async Task<bool> UpsertAsync(PrepFile preparedFile)
        {
            return await _repository.ReplaceAsync(r => r.IAID == preparedFile.IAID, preparedFile, new UpdateOptions { IsUpsert = true });
        }
    }
}
