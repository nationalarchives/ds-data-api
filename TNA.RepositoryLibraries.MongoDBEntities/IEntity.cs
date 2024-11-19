using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace TNA.RepositoryLibraries.MongoDBEntities
{
    /// <summary>
    /// MongoDB entity interface
    /// </summary>
    public interface IEntity
    {
        /// <summary>
        /// Id in string format ("_id" field in MongoDB)
        /// </summary>
        [BsonId]
        string Id { get; set; }

        /// <summary>
        /// Modify date
        /// </summary>
        DateTime ModifiedOn { get; }

        /// <summary>
        /// Id ("_id" field in MongoDB) in ObjectId format
        /// </summary>
        [BsonIgnore]
        ObjectId ObjectId { get; }
    }
}