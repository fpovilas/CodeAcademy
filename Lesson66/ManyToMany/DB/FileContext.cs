using Microsoft.EntityFrameworkCore;
using ManyToMany.Model;

namespace ManyToMany.DB
{
    internal class FileContext : DbContext
    {
        public DbSet<FileDB> FilesDB { get; set; }
        public DbSet<FolderDB> FoldersDB { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
                => optionsBuilder.UseSqlServer(@"Server=(localDB)\MSSQLLocalDB;Database=FilesDB;Trusted_Connection=True;");
    }
}
