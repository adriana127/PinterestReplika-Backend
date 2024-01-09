using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using PinterestReplika_Core.Models.NoSqlEntities;
using PinterestReplika_DataAccess.Contexts;

namespace PinterestReplika_Services
{
    public abstract class BaseMongoRepository<T> where T : BaseMongoEntity
    {
        protected readonly IMongoCollection<T> mongoCollection;

        public BaseMongoRepository(IOptions<PinterestReplikaDbMongoSettings> pinterestReplikaDbMongoSettings, IMongoClient client)
        {
            var database = client.GetDatabase(pinterestReplikaDbMongoSettings.Value.DatabaseName);
            if(typeof(T).Equals(typeof(PostMetadata)))
            { 
                mongoCollection = database.GetCollection<T>(pinterestReplikaDbMongoSettings.Value.PostMetadataCollection);
            }
        }


        public async Task<T?> Create(T entity)
        {
            entity.Id = ObjectId.GenerateNewId().ToString();
            await mongoCollection.InsertOneAsync(entity);
            return entity;
        }

        public async Task<T?> GetById(string id)
        {
            return await mongoCollection.Find(T => T.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<T>> GetAll()
        {
            return await mongoCollection.Find(s => true).ToListAsync();
        }

    }
}
