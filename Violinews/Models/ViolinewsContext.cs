using Microsoft.EntityFrameworkCore;

namespace Violinews.Models
{
    public class ViolinewsContext : DbContext
    {
        public ViolinewsContext(DbContextOptions<ViolinewsContext> options) : base(options)
        { 
        }


        public DbSet<Post> Posts { get; set; } = default!;
    }
}
