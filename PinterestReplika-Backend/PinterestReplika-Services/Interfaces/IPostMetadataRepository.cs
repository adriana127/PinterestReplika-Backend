using PinterestReplika_Core.Models.NoSqlEntities;

namespace PinterestReplika_Repositories.Interfaces
{
    public interface IPostMetadataRepository
    {
        Task<PostMetadata?> Create(PostMetadata postMetadata);
        Task<PostMetadata?> GetById(string id);
        Task<List<PostMetadata>> GetAll();
    }
}
