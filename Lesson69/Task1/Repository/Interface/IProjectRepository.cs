using Task1.Models;

namespace Task1.Repository.Interface
{
    internal interface IProjectRepository
    {
        public void CreateProject(Project project);
        public IEnumerable<Project> ReadProjectByID(int id);
        public string UpdateProject(Project project);
        public void DeleteProject(int id);
    }
}
