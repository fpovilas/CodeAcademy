using FinalProject.Database.Entity;

namespace FinalProject.Database.Repository.Interface
{
    public interface IUserRepository
    {
        User? FindById(int id);
        User? FindByUsername(string username);
        void SignUp(User user);
    }
}
