using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using PinterestReplika_Core.Models.NoSqlEntities;
using PinterestReplika_DataAccess.Contexts;
using PinterestReplika_Repositories.Interfaces;
using PinterestReplika_Services;

namespace PinterestReplika_Repositories
{
    public class PostMetadataRepository : BaseMongoRepository<PostMetadata>, IPostMetadataRepository
    {
        public PostMetadataRepository(IOptions<PinterestReplikaDbMongoSettings> schoolDatabaseSettings, IMongoClient client) : base(schoolDatabaseSettings, client) { }
    }
}
