using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using TNA.RepositoryLibraries.MongoDB;
using TNA.RepositoryLibraries.MongoDBEntities;

namespace TNA.DataDefinitionObjects
{
    [BsonIgnoreExtraElements]
    [ConnectionName("PreparedFileConnection")]
    [CollectionName("PreparedFiles")]
    public class PrepFile : Entity
    {
        public string IAID { get; set; }
        public int PercentCompleted { get; set; }
        public int Count { get; set; }
        public long LastDownloadTimestamp { get; set; }
        public string LastDownloadTimestampPretty { get; set; }
        public List<PreparedFileItem> Parts { get; set; }

        public PrepFile()
        {
            Parts = new List<PreparedFileItem>();
        }
    }
}
