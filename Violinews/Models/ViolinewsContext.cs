using Microsoft.EntityFrameworkCore;

namespace Violinews.Models
{
    public class ViolinewsContext : DbContext
    {
        public DbSet<Post> Posts { get; set; } = default!;

        public ViolinewsContext(DbContextOptions<ViolinewsContext> options) : base(options)
        { 
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>().HasData(new Post[]
            {
                new Post(Guid.NewGuid(), "Broke my E string", "so i was playing mendelssohn and i broke my E string", DateTime.Now.AddHours(-1)),
                new Post(Guid.NewGuid(), "Got a new set of strings", "so i broke my E string but i got a new set of strings", DateTime.Now)
            });
    
        }

    }
}
