using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace FinalProject.Database.Database
{
    public class PRSDbContextFactory : IDesignTimeDbContextFactory<PRSDbContext>
    {
        private readonly IConfiguration? _configuration;

        public PRSDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<PRSDbContext>();
            optionsBuilder.UseSqlServer(_configuration?.GetConnectionString("Database"));

            return new PRSDbContext(optionsBuilder.Options);
        }
    }
}