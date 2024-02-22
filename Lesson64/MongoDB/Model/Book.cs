using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MongoDB.Model
{
    internal class Book
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? ID { get; set; }
        public string? Name { get; set; }
        public List<Page>? Pages { get; set; }
    }
}
