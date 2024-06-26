﻿using AutoMapper;
using FinalProject.Shared.DTOs;

namespace FinalProject.Database.Entity.AutoMapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<PersonalInformation, PersonalInformationDTO>()
                .ForMember(dst => dst.PlaceOfResidence, opt => opt.MapFrom(src => src.PlaceOfResidence))
                .ReverseMap();

            CreateMap<PersonalInformation, PersonalInformationWithIdDTO>()
                .ForMember(dst => dst.PlaceOfResidence, opt => opt.MapFrom(src => src.PlaceOfResidence))
                .ReverseMap();

            CreateMap<PersonalInformation, PersonalInformationUpdateDTO>()
                .ForMember(dst => dst.PlaceOfResidence, opt => opt.MapFrom(src => src.PlaceOfResidence))
                .ReverseMap();

            CreateMap<User, UserAdminDTO>()
                .ForMember(dst => dst.PersonalInformations, opt => opt.MapFrom(src => src.PersonalInformations))
                .ReverseMap();

            CreateMap<PersonalInformation, PersonalInformationAdminDTO>().ReverseMap();

            CreateMap<PlaceOfResidence, PlaceOfResidenceDTO>().ReverseMap();
            CreateMap<PlaceOfResidence, PlaceOfResidenceWithIdDTO>().ReverseMap();
            CreateMap<PlaceOfResidence, PlaceOfResidenceUpdateDTO>().ReverseMap();
        }
    }
}