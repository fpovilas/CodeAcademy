using FinalProject.Database.Entity;

namespace FinalProject.Database.Repository.Interface
{
    public interface IPersonalInfoRepository
    {
        void Delete(PersonalInformation personalInfo);
        PersonalInformation Get(int id, string username);
        IEnumerable<PersonalInformation> GetAll(string username);
        string GetProfilePicture(int idPI, string username);
        void Put(PersonalInformation personalInfo);
        void Update(PersonalInformation personalInformation);
    }
}
