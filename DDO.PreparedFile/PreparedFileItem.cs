using MongoDB.Bson.Serialization.Attributes;

namespace TNA.DataDefinitionObjects
{
    public class PreparedFileItem
    {
        public string FileName { get; set; }
        [BsonIgnoreIfDefault]
        public int FromImage { get; set; }
        [BsonIgnoreIfDefault]
        public int ToImage { get; set; }
        public string ContentType { get; set; }
    }
}
