using JWTAuth.Models;
using Microsoft.EntityFrameworkCore;

namespace JWTAuth.DB
{
    public class UserContext(DbContextOptions<UserContext> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }
    }
}
