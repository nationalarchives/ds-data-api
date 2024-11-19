using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace TNA.RepositoryLibraries.MongoDBEntities
{
    /// <summary>
    /// Entity wrapper for non-editable models
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Entity<T> : Entity
    {
        /// <summary>
        /// Generic content
        /// </summary>
        public T Content { get; set; }
    }

    /// <summary>
    /// MongoDB entity base class
    /// </summary>
    [BsonIgnoreExtraElements(Inherited = true)]
    public class Entity : IEntity
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public Entity()
        {
            //Id = ObjectId.GenerateNewId().ToString();
        }

        /// <summary>
        /// Id in string format ("_id" field in MongoDB)
        /// </summary>
        [BsonElement(Order = 0)]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonIgnoreIfDefault]
        public string Id { get; set; }

        /// <summary>
        /// Modify date
        /// </summary>
        [BsonElement("_m", Order = 1)]
        [BsonRepresentation(BsonType.DateTime)]
        [BsonIgnoreIfDefault]
        public DateTime ModifiedOn { get; set; }

        /// <summary>
        /// Id ("_id") in ObjectId format
        /// </summary>
        public ObjectId ObjectId => ObjectId.Parse(Id);
    }
}