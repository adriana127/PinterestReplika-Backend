namespace PinterestReplika_DataAccess.Contexts
{
    /// <summary>
    /// Stores connection details for NoSql MongoDb
    /// </summary>
    public class PinterestReplikaDbMongoSettings
    {
        public string PostMetadataCollection { get; set; } = null!;
        public string ConnectionString { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
    }
}
