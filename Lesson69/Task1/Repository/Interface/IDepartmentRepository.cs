using Task1.Models;

namespace Task1.Repository.Interface
{
    internal interface IDepartmentRepository
    {
        public void CreateDepartment(Department department);
        public IEnumerable<Department> GetDepartmentByName(string name);
        public void UpdateDepartment(Department department);
        public void DeleteDepartment(Department department);
    }
}
