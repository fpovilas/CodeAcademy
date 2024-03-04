using Task1.Models;

namespace Task1.Repository.Interface
{
    internal interface IEmployeeRepository
    {
        public void CreateEmployee(Employee employee);
        public IEnumerable<Employee> GetAllEmployees();
        public void UpdateEmployeeByPersonalCode(string personalCode, Employee employee);
        public void DeleteEmployeeByPersonalCode(string personalCode);
    }
}
