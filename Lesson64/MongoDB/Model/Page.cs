using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MongoDB.Model
{
    internal class Page
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? ID { get; set; }
        public string? Content { get; set; }
    }
}
