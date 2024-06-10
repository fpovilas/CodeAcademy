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
            var userInDb = context.Users.FirstOrDefault(u => u.Username!.Equals(user.Username));

            if (userInDb != null) { throw new Exception("User already exists."); }

            context.Users.Add(user);
            context.SaveChanges();
        }

        public User? FindByUsername(string username)
            => context.Users
            .Include(u => u.PersonalInformations)
            .FirstOrDefault(u => u.Username!.Equals(username));

        public User? FindById(int id)
            => context.Users
                .Include(u => u.PersonalInformations)
                !.ThenInclude(pi => pi.PlaceOfResidence)
                .FirstOrDefault(u => u.Id == id)!;

        public IEnumerable<User> GetAll()
            => context!.Users!.Include(u => u.PersonalInformations)!.ThenInclude(pi => pi.PlaceOfResidence) ?? throw new Exception("User does not exist.");

        public User Get(int idU)
            => context!.Users
                            !.Include(u => u.PersonalInformations)
                            !.ThenInclude(pi => pi.PlaceOfResidence)
                            !.FirstOrDefault(u => u.Id == idU) ?? throw new Exception("User does not exist.");

        public bool Delete(User user)
        {
            try
            {
                context.Users.Remove(user);
                context.SaveChanges();
                return true;
            }
            catch { return false; }
        }
    }
}
