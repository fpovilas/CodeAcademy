using Atm.Dto;
using Atm.Model;

namespace Atm.Interfaces
{
    public interface ICustomerRepository
    {
        string Login(CustomerLoginDto customer);
        public void CreateCustomer(Customer customer);
    }
}
