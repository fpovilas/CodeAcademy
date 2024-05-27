using JWTAuth.Models;
using Microsoft.EntityFrameworkCore;

namespace JWTAuth.DB
{
    public class CarContext(DbContextOptions<CarContext> options) : DbContext(options)
    {
        public DbSet<Car> Cars { get; set; }
    }
}