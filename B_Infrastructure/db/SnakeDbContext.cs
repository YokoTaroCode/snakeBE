using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using D_Domain;
using B_Infrastructure.configurations;

namespace B_Infrastructure.db
{
    public class SnakeDbContext : DbContext 
    {
        // costruttore solito 
        // collections 
        // on model creating con la mia configurazione figa 
        public SnakeDbContext(DbContextOptions options) : base(options){}

        public DbSet<User> Users { get; set; }
        public DbSet<Game> Games { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(GameConfig).Assembly)
        }
    }
}
