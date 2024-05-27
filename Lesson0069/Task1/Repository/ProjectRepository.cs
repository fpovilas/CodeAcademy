using Dapper;
using System.Data;
using System.Data.SqlClient;
using Task1.Models;
using Task1.Repository.Interface;

namespace Task1.Repository
{
    internal class ProjectRepository(string connectionString) : IProjectRepository
    {
        private readonly string _connectionString = connectionString;

        public IDbConnection Connection => new SqlConnection(_connectionString);

        // Create, Update, Read, Delete

        public void CreateProject(Project project)
        {
            string createQuery = "INSERT INTO Project (ID, Name) VALUES (@ID, @Name);";

            using(var dbConn = Connection)
            {
                dbConn.Open();
                dbConn.Execute(createQuery, project);
            }
        }

        public IEnumerable<Project> ReadProjectByID(int id)
        {
            string readQuery = "SELECT * FROM Project WHERE ID = @ID";
            using(var dbConn = Connection)
            {
                dbConn.Open();
                return dbConn.Query<Project>(readQuery, new {ID = id}).ToList();
            }
        }

        public string UpdateProject(Project project)
        {
            string updateQuery = "UPDATE Project SET ID = @ID, Name = @Name WHERE ID = @ID";
            try
            {
                using (var dbConn = Connection)
                {
                    dbConn.Open();
                    dbConn.Execute(updateQuery, project);
                    return "Update successful";
                }
            }
            catch (Exception ex)
            {
                return $"Update Failed because {ex.Message}";
            }
        }

        public void DeleteProject(int id)
        {
            string deleteQuery = "DELETE FROM Project WHERE ID = @ID";

            using( var dbConn = Connection)
            {
                dbConn.Open();
                dbConn.Execute(deleteQuery, new {ID = id});
            }
        }
    }
}
