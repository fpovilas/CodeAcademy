using AutoMapper;
using FinalProject.Database.Database;
using FinalProject.Database.Entity;
using FinalProject.Database.Repository.Interface;
using FinalProject.Shared.DTOs;

namespace FinalProject.Database.Repository
{
    public class PersonalInfoRepository(PRSDbContext context, IMapper mapper) : IPersonalInfoRepository
    {
        public IEnumerable<PersonalInformationDTO> GetAll(string username)
        {
            var allPIR = context.PersonalInformations
                .Where(pir => pir.User!.Username!.Equals(username)).ToList();

            var dtoPIR = mapper.Map<List<PersonalInformationDTO>>(allPIR);

            return dtoPIR;
        }

        public void Put(PersonalInformation personalInfo)
        {
            context.PersonalInformations.Add(personalInfo);
            context.SaveChanges();
        }
    }
}