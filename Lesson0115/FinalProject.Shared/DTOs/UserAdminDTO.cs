namespace FinalProject.Shared.DTOs
{
    public class UserAdminDTO
    {
        public int Id { get; set; }
        public string? Username { get; set; }
        public string? Role { get; set; }

        // One-to-Many with PersonalInformation
        public ICollection<PersonalInformationAdminDTO>? PersonalInformations { get; set; }
    }
}
