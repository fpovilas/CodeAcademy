namespace FinalProject.Shared.DTOs
{
    public class PlaceOfResidenceWithIdDTO
    {
        public int Id { get; set; }
        public required string City { get; set; }
        public required string Street { get; set; }
        public required string HouseNumber { get; set; }
        public string? ApartmentNumber { get; set; }
    }
}