using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PinterestReplika_Core.Models;

namespace PinterestReplika_DataAccess.Contexts
{
    /// <summary>
    /// Represent the PinterestReplika SQL DbContext
    /// </summary>
    public class PinterestReplikaSqlDbContext: IdentityDbContext<User>
    {
        public PinterestReplikaSqlDbContext(DbContextOptions<PinterestReplikaSqlDbContext> options) : base(options) { }

        public virtual DbSet<Post> Posts { get; set; }
    }
}
