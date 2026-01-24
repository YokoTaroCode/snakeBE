using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

namespace B_Infrastructure.db
{
    internal class dbContextFactory : IDesignTimeDbContextFactory<SnakeDbContext>
    {

        public SnakeDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot confBuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            DbContextOptionsBuilder<SnakeDbContext> optionsBuilder = new();
            string conn = confBuilder["ConnectionStrings:Default"];
            if(conn == null)
            {
                throw new InvalidOperationException("Connection string 'Default' not found.");
            }
            optionsBuilder.UseSqlServer(conn);

            return new SnakeDbContext(optionsBuilder.Options);
        }
    }
}