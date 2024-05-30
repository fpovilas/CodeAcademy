//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Design;
//using Microsoft.Extensions.Configuration;

//namespace FinalProject.Database.Database
//{
//    public class PRSDbContextFactory : IDesignTimeDbContextFactory<PRSDbContext>
//    {
//        private readonly IConfiguration? _configuration;

//        public PRSDbContext CreateDbContext(string[] args)
//        {
//            var optionsBuilder = new DbContextOptionsBuilder<PRSDbContext>();
//            var connString = _configuration!.GetConnectionString("Database");
//            optionsBuilder.UseSqlServer(connString);

//            return new PRSDbContext(optionsBuilder.Options);
//        }
//    }
//}

// Uncomment when scaffolding is needed
// Better solution https://gist.github.com/ShawnShiSS/c32b3e253804ca6c3b37c70b1ce0f36d