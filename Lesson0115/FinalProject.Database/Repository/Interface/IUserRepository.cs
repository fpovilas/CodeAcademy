using FinalProject.Database.Entity;

namespace FinalProject.Database.Repository.Interface
{
    public interface IUserRepository
    {
        bool Delete(User user);
        User? FindById(int id);
        User? FindByUsername(string username);
        User Get(int idU);
        IEnumerable<User> GetAll();
        void SignUp(User user);
    }
}
