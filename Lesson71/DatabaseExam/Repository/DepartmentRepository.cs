using DatabaseExam.Database;
using DatabaseExam.Database.Models;
using DatabaseExam.Repository.Interface;

namespace DatabaseExam.Repository
{
    public class DepartmentRepository(StudentISContext context) : IDepartmentRepository
    {
        private readonly StudentISContext studentISContext = context;

        public int AddDepartment(Department department)
        {
            studentISContext.Departments.Add(department);
            studentISContext.SaveChanges();

            return department.Id;
        }

        public Department GetDepartmentByID(int departmentId)
            => studentISContext.Departments.FirstOrDefault(dID => dID.Id == departmentId) ?? new();

        public Department GetDepartmentByName(string name)
            => studentISContext.Departments.FirstOrDefault(dName => dName.Name == name) ?? new();

        public List<Department> GetAllDepartments()
            => studentISContext.Departments.ToList() ?? [];

        public void UpdateDepartment(Department departmentIn)
        {
            studentISContext.Departments.Update(departmentIn);
            studentISContext.SaveChanges();
        }

        public void DeleteDepartmentByID(int departmentId)
        {
            studentISContext.Departments.Remove(GetDepartmentByID(departmentId));
        }
    }
}
