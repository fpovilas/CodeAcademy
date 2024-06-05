using FinalProject.Database.Database;
using FinalProject.Database.Entity;
using FinalProject.Database.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Database.Repository
{
    public class PersonalInfoRepository(PRSDbContext context) : IPersonalInfoRepository
    {
        public IEnumerable<PersonalInformation> GetAll(string username)
        {
            var allPI = context.PersonalInformations
                .Include(pi => pi.PlaceOfResidence)
                .Include(pi => pi.User)
                .Where(pi => pi.User!.Username!.Equals(username)).ToList() ?? throw new Exception("Data does not exist.");

            return allPI;
        }

        public PersonalInformation Get(int id, string username)
        {
            var pI = context.PersonalInformations
                .Include(pi => pi.PlaceOfResidence)
                .Include(pi => pi.User)
                .FirstOrDefault(pi => pi.User!.Username!.Equals(username) && pi.Id == id) ?? throw new Exception("Data does not exist.");

            return pI;
        }

        public void Put(PersonalInformation personalInfo)
        {
            context.PersonalInformations.Add(personalInfo);
            context.SaveChanges();
        }

        public void Update(PersonalInformation personalInformation)
        {
            context.PersonalInformations.Update(personalInformation);
            context.SaveChanges();
        }

        public void Delete(PersonalInformation personalInfo)
        {
            context.Remove(personalInfo);
            context.SaveChanges();
        }

        public string GetProfilePicture(int idPI, string username)
        {
            var pI = context.PersonalInformations
                .Include(pi => pi.PlaceOfResidence)
                .Include(pi => pi.User)
                .FirstOrDefault(pi => pi.User!.Username!.Equals(username) && pi.Id == idPI);

            if (pI is null)
            { throw new Exception("Data does not exist."); }
            else
            {
                if (pI.ProfilePicturePath is null)
                { throw new Exception("Given Personal Information does not have profile picture."); }

                return pI.ProfilePicturePath;
            }
        }
    }
}