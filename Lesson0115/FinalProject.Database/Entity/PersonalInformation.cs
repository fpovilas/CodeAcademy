namespace FinalProject.Database.Entity
{
    public class PersonalInformation
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public string? Gender { get; set; }
        public DateOnly? Birthday { get; set; }
        public string? PersonalCode { get; set; }
        public string? PhoneNumber { get; set; }
        public string? EmailAddress { get; set; }
        public string? ProfilePicturePath { get; set; }

        // One-to-many relationship with User
        public int UserId { get; set; }
        public virtual User? User { get; set; }

        // One-to-one relationship with PlaceOfResidence
        public virtual PlaceOfResidence? PlaceOfResidence { get; set; }
    }
}