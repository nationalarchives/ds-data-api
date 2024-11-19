using MongoDB.Bson.Serialization.Attributes;

namespace TNA.DataDefinitionObjects
{
    public class FileEditSet
    {
        public int Init { get; set; }
        public int Curt { get; set; }
        public string Name { get; set; }
        [BsonIgnoreIfDefault]
        public string OrigName { get; set; }
        public int Size { get; set; }
        public string Frmt { get; set; }
        [BsonIgnoreIfDefault]
        public Action Action { get; set; }
    }
}
