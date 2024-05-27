using Microsoft.EntityFrameworkCore;
using MultiProjectStructure.Database.Entities;

namespace MultiProjectStructure.Database.Migrations.Context
{
    public class ImageDbContext(DbContextOptions<ImageDbContext> options) : DbContext(options)
    {
        public DbSet<CustomImage> Images { get; set; }
        public DbSet<CustomImageThumbnail> ImageThumbnails { get; set; }
    }
}
