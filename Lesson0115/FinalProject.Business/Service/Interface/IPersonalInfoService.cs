using FinalProject.Shared.DTOs;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace FinalProject.Business.Service.Interface
{
    public interface IPersonalInfoService
    {
        string AdminDelete(int idPi, IEnumerable<Claim> claims, out PersonalInformationAdminDTO? deletedPI);
        string Delete(int id, string username);
        PersonalInformationWithIdDTO Get(int id, string username);
        IEnumerable<PersonalInformationWithIdDTO> GetAll(string username);
        bool GetProfilePicture(int idPI, string username, out string msg, out string profilePicturePath);
        void Put(PersonalInformationDTO personalInformationDTO, IFormFile file, string? username);
        PersonalInformationUpdateDTO Update(PersonalInformationUpdateDTO personalInformation, IFormFile file, int idPI, string username);
    }
}