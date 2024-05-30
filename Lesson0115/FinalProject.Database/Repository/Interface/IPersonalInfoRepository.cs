using FinalProject.Database.Entity;
using FinalProject.Shared.DTOs;

namespace FinalProject.Database.Repository.Interface
{
    public interface IPersonalInfoRepository
    {
        IEnumerable<PersonalInformationDTO> GetAll(string username);
        void Put(PersonalInformation personalInfo);
    }
}
