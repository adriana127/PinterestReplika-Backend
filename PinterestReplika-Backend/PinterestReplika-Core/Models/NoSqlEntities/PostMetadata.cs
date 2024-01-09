using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PinterestReplika_Core.Models.NoSqlEntities
{
    public class PostMetadata : BaseMongoEntity
    {
        public int ViewsNumber { get; set; }
    }
}
