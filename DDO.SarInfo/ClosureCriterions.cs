using TNA.RepositoryLibraries.MongoDB;
using TNA.RepositoryLibraries.MongoDBEntities;

namespace TNA.DataDefinitionObjects
{
    [ConnectionName("SarConnection")]
    [CollectionName("ClosureCriterions")]
    public class ClosureCriterions : Entity
    {
        public string Code { get; set; }
        public string Description { get; set; }
    }
}
