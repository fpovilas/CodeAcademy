using FinalProject.Database.Database;
using FinalProject.Database.Entity;
using FinalProject.Database.Repository.Interface;

namespace FinalProject.Database.Repository
{
    public class UserRepository(PRSDbContext context) : IUserRepository
    {
        public void SignUp(User user)
        {
            context.Users.Add(user);
            context.SaveChanges();
        }

        public User? FindByUsername(string username)
            => context.Users.FirstOrDefault(u => u.Username!.Equals(username));
    }
}
