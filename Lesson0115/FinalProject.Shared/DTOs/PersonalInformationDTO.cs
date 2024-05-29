namespace FinalProject.Shared.DTOs
{
    public class PersonalInformationDTO
    {
        public required string Name { get; set; }
        public required string LastName { get; set; }
        public required string Gender { get; set; }
        public required DateOnly Birthday { get; set; }
        public required string PersonalCode { get; set; }
        public required string PhoneNumber { get; set; }
        public required string EmailAddress { get; set; }
        public required PlaceOfResidenceDTO PlaceOfResidence { get; set; }
    }
}