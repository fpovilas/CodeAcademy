using DatabaseExam.Database;
using DatabaseExam.Database.Models;
using DatabaseExam.Repository.Interface;

namespace DatabaseExam.Repository
{
    internal class DepartmentRepository(StudentISContext context) : IDepartmentRepository
    {
        private readonly StudentISContext studentISContext = context;

        public int AddDepartment(Department department)
        {
            studentISContext.Departments.Add(department);
            studentISContext.SaveChanges();

            return studentISContext.Departments.FirstOrDefault(dID => dID.Id == department.Id)!.Id;
        }

        public Department GetDepartmentByID(int departmentId)
            => studentISContext.Departments.FirstOrDefault(dID => dID.Id == departmentId) ?? new();

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
