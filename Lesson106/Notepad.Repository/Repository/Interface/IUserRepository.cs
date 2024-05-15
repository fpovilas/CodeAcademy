using Notepad.Repository.Model;

namespace Notepad.Repository.Repository.Interface
{
    public interface IUserRepository
    {
        public void Register(User user);
        public User FindByUsername(string username);
    }
}
