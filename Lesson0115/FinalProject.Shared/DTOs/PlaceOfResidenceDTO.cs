namespace FinalProject.Shared.DTOs
{
    public class PlaceOfResidenceDTO
    {
        public required string City { get; set; }
        public required string Street { get; set; }
        public required string HouseNumber { get; set; }
        public required string ApartmentNumber { get; set; }
    }
}