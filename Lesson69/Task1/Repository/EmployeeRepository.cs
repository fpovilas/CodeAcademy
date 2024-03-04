using System.Data.SqlClient;
using System.Data;
using Task1.Repository.Interface;
using Task1.Models;
using Dapper;

namespace Task1.Repository
{
    internal class EmployeeRepository(string connectionString) : IEmployeeRepository
    {
        private readonly string _connectionString = connectionString;

        public IDbConnection Connection => new SqlConnection(_connectionString);

        public void CreateEmployee(Employee employee)
        {
            try
            {
                using (var dbConn = Connection)
                {
                    dbConn.Open();
                    dbConn.Execute("InsertEmployee", employee);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            try
            {
                using (var dbConn = Connection)
                {
                    dbConn.Open();
                    return dbConn.Query<Employee>("SelectAllEmployees", commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Enumerable.Empty<Employee>();
            }
        }

        public void UpdateEmployeeByPersonalCode(string personalCode, Employee employee)
        {
            string updateQuery = $"UPDATE Employee SET PersonalCode = @PersonalCode, FirstName = @FirstName, LastName = @LastName, StartDate = @StartDate, BirthDate = @BirthDate, Position = @Position, DepartmentName = @DepartmentName, ProjectID = @ProjectID WHERE PersonalCode = @pCode";
            using (var dbConn = Connection)
            {
                dbConn.Open();
                dbConn.Execute(updateQuery, new { PersonalCode = employee.PersonalCode, FirstName = employee.FirstName, LastName = employee.LastName, StartDate = employee.StartDate, BirthDate = employee.BirthDate, Position = employee.Position, DepartmentName = employee.DepartmentName, ProjectID = employee.ProjectID, pCode = personalCode });
                //dbConn.Execute(updateQuery, new { pCode = personalCode });
            }
        }

        public void DeleteEmployeeByPersonalCode(string personalCode)
        {
            string deleteQuery = "DELETE FROM Employee WHERE PersonalCode = @personalCode;";
            using(var dbConn = Connection)
            {
                dbConn.Open();
                dbConn.Execute(deleteQuery, new { personalCode });
            }
        }
    }
}
