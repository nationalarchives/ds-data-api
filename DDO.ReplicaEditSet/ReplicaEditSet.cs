using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using TNA.RepositoryLibraries.MongoDB;
using TNA.RepositoryLibraries.MongoDBEntities;

namespace TNA.DataDefinitionObjects
{
    [ConnectionName("ReplicaConnection")]
    [CollectionName("ReplicaEditSet")]
    public class ReplEditSet : Entity
    {
        public string RID { get; set; }
        public string IAID { get; set; }
        public string Usr { get; set; }
        public DateTime Req { get; set; }

        [BsonIgnoreIfDefault]
        public DateTime Sub { get; set; }

        public List<FileEditSet> Files { get; set; }
    }
}