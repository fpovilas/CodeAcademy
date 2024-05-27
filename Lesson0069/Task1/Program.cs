using Task1.Models;
using Task1.Repository;
using Task1.Repository.Interface;

namespace Task1
{
    internal class Program
    {
        static void Main()
        {
            //string connectionString =
            //        @"Server=(LocalDb)\MSSQLLocalDB;Database=Lesson68;Trusted_Connection=True";

            //IDepartmentRepository departmentRepository = new DepartmentRepository(connectionString);
            // departmentRepository.CreateDepartment(new() { Name = ".Net", ManagerPersonalCode = "37803142412" });
            //IEnumerable<Department> javaDepartment = departmentRepository.GetDepartmentByName("Java");
            //departmentRepository.DeleteDepartment(javaDepartment);

            // ----------------------------------------------------------------

            //IProjectRepository projectRepository = new ProjectRepository(connectionString);
            //projectRepository.CreateProject(new Project() { ID = 4, Name = "Nemesis" });

            //IEnumerable<Project> project = projectRepository.ReadProjectByID(4);
            //Console.WriteLine(project.First().ID + " " + project.First().Name);

            //projectRepository.UpdateProject(new Project() { ID = 4, Name = "Poki" });

            //projectRepository.DeleteProject(4);

            // ----------------------------------------------------------------

            //IEmployeeRepository employeeRepository = new EmployeeRepository(connectionString);

            //Employee employee = new()
            //{
            //    PersonalCode = "38708081858",
            //    FirstName = "Povilas",
            //    LastName = "Fri",
            //    BirthDate = DateTime.Parse("1987-08-08"),
            //    StartDate = DateTime.Parse("2010-02-02"),
            //    DepartmentName = "C#",
            //    Position = "Developer",
            //    ProjectID = 1
            //};
            //employeeRepository.CreateEmployee(employee);

            //foreach(Employee employee in employeeRepository.GetAllEmployees())
            //{
            //    Console.WriteLine(employee);
            //}

            //employeeRepository.UpdateEmployeeByPersonalCode("38708081558", employee);

            //employeeRepository.DeleteEmployeeByPersonalCode("38708081858");
        }
    }
}
