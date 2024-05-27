using DatabaseExam.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace DatabaseExam.Database
{
    public class StudentISContext : DbContext
    {
        public StudentISContext() { }
        public StudentISContext(DbContextOptions options) : base(options)
        {
        }

        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Lecture> Lectures { get; set; }
        public virtual DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
                optionsBuilder
                    .UseLazyLoadingProxies()
                    .UseSqlServer(@"Server=(localDB)\MSSQLLocalDB;Database=StudentIS;Trusted_Connection=True;");
        }

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
