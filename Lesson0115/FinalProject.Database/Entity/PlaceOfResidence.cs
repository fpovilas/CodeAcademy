namespace FinalProject.Database.Entity
{
    public class PlaceOfResidence
    {
        public int Id { get; set; }
        public string? City { get; set; }
        public string? Street { get; set; }
        public string? HouseNumber { get; set; }
        public string? ApartmentNumber { get; set; }

        // One-to-one relationship with PersonalInformation
        public int? PersonalInformationId { get; set; }
        public virtual PersonalInformation? PersonalInformation { get; set; }
    }
}