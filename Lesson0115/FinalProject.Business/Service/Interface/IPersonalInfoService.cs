using FinalProject.Shared.DTOs;
using Microsoft.AspNetCore.Http;

namespace FinalProject.Business.Service.Interface
{
    public interface IPersonalInfoService
    {
        IEnumerable<PersonalInformationDTO> GetAll(string username);
        void Put(PersonalInformationDTO personalInformationDTO, IFormFile file, string? username);
    }
}