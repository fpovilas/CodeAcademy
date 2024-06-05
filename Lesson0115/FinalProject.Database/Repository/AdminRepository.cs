using FinalProject.Database.Database;
using FinalProject.Database.Entity;
using FinalProject.Database.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Database.Repository
{
    public class AdminRepository(PRSDbContext context) : IAdminRepository
    {
        public IEnumerable<User> GetAll()
            => context!.Users!.Include(u => u.PersonalInformations)!.ThenInclude(pi => pi.PlaceOfResidence) ?? throw new Exception("User does not exist.");

        public User Get(int idU)
            => context!.Users
                            !.Include(u => u.PersonalInformations)
                            !.ThenInclude(pi => pi.PlaceOfResidence)
                            !.FirstOrDefault(u => u.Id == idU) ?? throw new Exception("User does not exist.");
    }
}
