namespace FinalProject.Database.Models
{
    public class ProfilePhoto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string ContentType { get; set; }
        public required string PicturePath { get; set; }

        // One-to-one relationship with PersonalInformation
        public int? PersonalInformationId { get; set; }
        public virtual PersonalInformation? PersonalInformation { get; set; }
    }
}
