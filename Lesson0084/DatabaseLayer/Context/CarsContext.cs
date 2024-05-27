using DatabaseLayer.Database.Model;
using Microsoft.EntityFrameworkCore;

namespace DatabaseLayer.Context
{
    public class CarsContext(DbContextOptions<CarsContext> options) : DbContext(options)
    {
        public DbSet<Car> Cars { get; set; }
    }
}