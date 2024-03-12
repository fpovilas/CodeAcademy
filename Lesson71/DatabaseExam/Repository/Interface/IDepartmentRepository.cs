using DatabaseExam.Database.Models;

namespace DatabaseExam.Repository.Interface
{
    internal interface IDepartmentRepository
    {
        public int AddDepartment(Department department);
        public Department GetDepartmentByID(int departmentId);
        public Department GetDepartmentByName(string departmentName);
        public List<Department> GetAllDepartments();
        public void UpdateDepartment(Department departmentIn);
        public void DeleteDepartmentByID(int departmentId);
    }
}
