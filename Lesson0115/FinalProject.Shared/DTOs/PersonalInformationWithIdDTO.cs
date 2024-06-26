﻿using FinalProject.Shared.Enums;

namespace FinalProject.Shared.DTOs
{
    public class PersonalInformationWithIdDTO
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string LastName { get; set; }
        public required Gender Gender { get; set; }
        public required DateOnly Birthday { get; set; }
        public required string PersonalCode { get; set; }
        public required string PhoneNumber { get; set; }
        public required string EmailAddress { get; set; }
        public required PlaceOfResidenceWithIdDTO PlaceOfResidence { get; set; }
    }
}