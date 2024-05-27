using Microsoft.EntityFrameworkCore;
using Task1.Database.Models;

namespace Task1.Database
{
    public class ATMContext : DbContext
    {
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
                => optionsBuilder.UseSqlServer(@"Server=(localDB)\MSSQLLocalDB;Database=ATM;Trusted_Connection=True;");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasSequence<int>("AccountsSeq", schema: "dbo")
                .StartsAt(1000)
                .IncrementsBy(5);

            modelBuilder.Entity<Account>()
                .Property(o => o.ID)
                .HasDefaultValueSql("NEXT VALUE FOR dbo.AccountsSeq");
        }


    }
}
