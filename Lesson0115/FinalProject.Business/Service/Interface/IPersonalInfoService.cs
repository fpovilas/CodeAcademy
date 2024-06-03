using FinalProject.Shared.DTOs;
using Microsoft.AspNetCore.Http;

namespace FinalProject.Business.Service.Interface
{
    public interface IPersonalInfoService
    {
        void Delete(int id, string username);
        IEnumerable<PersonalInformationDTO> GetAll(string username);
        void Put(PersonalInformationDTO personalInformationDTO, IFormFile file, string? username);
    }
}