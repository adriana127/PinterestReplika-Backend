using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PinterestReplika_Core.Models.NoSqlEntities
{
    public class BaseMongoEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
    }
}
