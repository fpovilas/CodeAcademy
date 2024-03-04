using Dapper;
using System.Data;
using System.Data.SqlClient;
using Task1.Models;
using Task1.Repository.Interface;

namespace Task1.Repository
{
    internal class DepartmentRepository(string connectionString) : IDepartmentRepository
    {
        private readonly string _connectionString = connectionString;

        public IDbConnection Connection => new SqlConnection(_connectionString);

        public void CreateDepartment(Department department)
        {
            string addDepartmentQuery = @"INSERT INTO Department (Name, ManagerPersonalCode) VALUES (@Name, @ManagerPersonalCode);";

            using (var dbConn = Connection)
            {
                dbConn.Open();
                dbConn.Execute(addDepartmentQuery, department);
            }
        }

        public IEnumerable<Department> GetDepartmentByName(string name)
        {
            string departmentQuery = "SELECT * FROM Department WHERE Name LIKE @Name;";
            using (var dbConn = Connection)
            {
                dbConn.Open();
                return dbConn.Query<Department>(departmentQuery, new Department() { Name = name}).ToList();
            }
        }

        public void UpdateDepartment(Department department)
        {
            string updateQuery = "UPDATE Department SET Name = @Name, ManagerPersonalCode = @ManagerPersonalCode WHERE ManagerPersonalCode LIKE @ManagerPersonalCode;";

            using (var dbConn = Connection)
            {
                dbConn.Open();
                dbConn.Execute(updateQuery, department);
            }
        }

        public void DeleteDepartment(Department department)
        {
            string deleteQuery = "DELETE FROM Department WHERE ManagerPersonalCode = @ManagerPersonalCode";

            using (var dbConn = Connection)
            {
                dbConn.Open();
                dbConn.Execute(deleteQuery, department);
            }
        }
    }
}
