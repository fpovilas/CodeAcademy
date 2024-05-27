using Atm.Database;
using Atm.Dto;
using Atm.Interfaces;
using Atm.Model;

namespace Atm.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AtmContext _context;
        public CustomerRepository(AtmContext context)
        {
            _context = context;
        }

        public string Login(CustomerLoginDto customer)
        {
            if (String.IsNullOrEmpty(customer.UserId)) throw new ArgumentNullException(nameof(customer.UserId));
            if (String.IsNullOrEmpty(customer.Password)) throw new ArgumentNullException(nameof(customer.Password));
            var existingCustomer = _context.Customers.FirstOrDefault(c => c.UserId == customer.UserId && c.Password == customer.Password);
            if (existingCustomer == null) throw new Exception("Invalid login");
            return existingCustomer.CustomerKey.ToString();
        }

        public void CreateCustomer(Customer customer)
        {
            try
            {
                _context.Customers.Add(customer);
                _context.SaveChanges();
            }
            catch (Exception Ex)
            {

                Console.WriteLine($"Message: {Ex.Message}, InnerMessage: {Ex.InnerException.Message}");
            }
        }
    }
}
