using Notepad.Repository.Database;
using Notepad.Repository.Model;
using Notepad.Repository.Repository.Interface;

namespace Notepad.Repository.Repository
{
    public class UserRepository(NotepadDbContext context) : IUserRepository
    {
        public void Register(User user)
        {
            context.Users.Add(user);
            context.SaveChanges();
        }

        public User FindByUsername(string userName)
            => context.Users.FirstOrDefault(u => u.Username!.Equals(userName)) ?? new();
    }
}
