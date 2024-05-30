using AutoMapper;
using FinalProject.Shared.DTOs;

namespace FinalProject.Database.Entity.AutoMapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<PersonalInformation, PersonalInformationDTO>().ReverseMap();
            CreateMap<PlaceOfResidence, PlaceOfResidenceDTO>().ReverseMap();
        }
    }
}