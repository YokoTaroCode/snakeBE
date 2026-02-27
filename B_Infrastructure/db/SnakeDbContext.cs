using Microsoft.EntityFrameworkCore;
using SnakeBE.Domain;

namespace SnakeBE.Infrastructure.db
{
    public class SnakeDbContext : DbContext 
    {
        public SnakeDbContext(DbContextOptions options) : base(options){}

        public DbSet<User> Users { get; set; }
        public DbSet<Game> Games { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        }
    }
}
