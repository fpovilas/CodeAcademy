using FinalProject.Database.Entity;

namespace FinalProject.Database.Repository.Interface
{
    public interface IAdminRepository
    {
        User Get(int idU);
        IEnumerable<User> GetAll();
    }
}