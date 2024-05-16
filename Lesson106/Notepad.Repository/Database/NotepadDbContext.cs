using Microsoft.EntityFrameworkCore;
using Notepad.Repository.Model;

namespace Notepad.Repository.Database
{
    public class NotepadDbContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<NoteImage> NoteImages { get; set; }
        public DbSet<NoteImageThumbnail> NoteImageThumbnails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasSequence<int>("UserIndex", schema: "dbo")
                .StartsAt(1)
                .IncrementsBy(1);

            modelBuilder.HasSequence<int>("NoteIndex", schema: "dbo")
                .StartsAt(1000)
                .IncrementsBy(5);

            modelBuilder.HasSequence<int>("TagIndex", schema: "dbo")
                .StartsAt(3)
                .IncrementsBy(3);

            modelBuilder.Entity<User>()
                .Property(uID => uID.Id)
                .HasDefaultValueSql("NEXT VALUE FOR dbo.UserIndex");

            modelBuilder.Entity<Note>()
                .Property(nID => nID.Id)
                .HasDefaultValueSql("NEXT VALUE FOR dbo.NoteIndex");

            modelBuilder.Entity<Tag>()
                .Property(tID => tID.Id)
                .HasDefaultValueSql("NEXT VALUE FOR dbo.TagIndex");
        }
    }
}
