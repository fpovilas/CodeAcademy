using FinalProject.Database.Database;
using FinalProject.Database.Entity;
using FinalProject.Database.Repository.Interface;
using Microsoft.EntityFrameworkCore;

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
            => context.Users
            .Include(u => u.PersonalInformations)
            .FirstOrDefault(u => u.Username!.Equals(username));
    }
}
