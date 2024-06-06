using FinalProject.Shared.Attributes;

namespace FinalProject.Shared.DTOs
{
    public class PlaceOfResidenceDTO
    {
        [CityValidation]
        public required string City { get; set; }
        [StreetValidation]
        public required string Street { get; set; }
        [HouseNumberValidation]
        public required string HouseNumber { get; set; }
        [ApartmentNumber]
        public string? ApartmentNumber { get; set; }
    }
}