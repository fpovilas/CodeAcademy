using DatabaseExam.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace DatabaseExam.Database
{
    internal class StudentISContext : DbContext
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<Lecture> Lectures { get; set; }
        public DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer(@"Server=(localDB)\MSSQLLocalDB;Database=StudentIS;Trusted_Connection=True;");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasSequence<int>("DepartmentIndex", schema: "dbo")
                .StartsAt(10000)
                .IncrementsBy(2);

            modelBuilder.HasSequence<int>("StudentIndex", schema: "dbo")
                .StartsAt(419)
                .IncrementsBy(1);

            modelBuilder.Entity<Department>()
                .Property(dID => dID.Id)
                .HasDefaultValueSql("NEXT VALUE FOR dbo.DepartmentIndex");

            modelBuilder.Entity<Student>()
                .Property(sID => sID.Id)
                .HasDefaultValueSql("NEXT VALUE FOR dbo.StudentIndex");
        }
    }
}
