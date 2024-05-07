using FileUploadDownloadAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace FileUploadDownloadAPI.Database
{
    public class ImageDbContext(DbContextOptions<ImageDbContext> options) : DbContext(options)
    {
        public DbSet<Image> Images { get; set; }
    }
}
