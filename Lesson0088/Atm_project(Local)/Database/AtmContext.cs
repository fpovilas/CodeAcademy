using Atm.Model;
using Microsoft.EntityFrameworkCore;

namespace Atm.Database
{
    public class AtmContext(DbContextOptions<AtmContext> options) : DbContext(options)
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
    }
}
