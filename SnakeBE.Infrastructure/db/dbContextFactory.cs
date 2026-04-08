using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace SnakeBE.Infrastructure.db
{
    internal class DbContextFactory : IDesignTimeDbContextFactory<SnakeDbContext>
    {
        public SnakeDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot confBuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            DbContextOptionsBuilder<SnakeDbContext> optionsBuilder = new();

            string conn = confBuilder["ConnectionStrings:Default"] 
                ?? throw new InvalidOperationException("Connection string 'Default' not found.");

            optionsBuilder.UseSqlServer(conn);

            return new SnakeDbContext(optionsBuilder.Options);
        }
    }
}