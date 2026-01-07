using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace B_Infrastructure.db
{
    internal class dbContextFactory : IDesignTimeDbContextFactory<SnakeDbContext>
    {

        public SnakeDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot c = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("root")
                .Build();

            DbContextOptionsBuilder<SnakeDbContext> optionsBuilder = new();
            string conn = c["Database:ConnectionString"] ?? "";
            optionsBuilder.UseSqlServer(conn);

            return new SnakeDbContext(optionsBuilder.Options);
        }
    }

}