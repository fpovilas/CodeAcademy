using FinalProject.Database.Entity;
using FinalProject.Shared.DTOs;

namespace FinalProject.Database.Repository.Interface
{
    public interface IPersonalInfoRepository
    {
        void Delete(PersonalInformation personalInfo);
        PersonalInformationWithIdDTO Get(int id, string username);
        IEnumerable<PersonalInformationWithIdDTO> GetAll(string username);
        string GetProfilePicture(int idPI, string username);
        void Put(PersonalInformation personalInfo);
    }
}
