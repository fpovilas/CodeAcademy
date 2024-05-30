using FinalProject.Shared.Enums;

namespace FinalProject.Database.Entity
{
    public class User
    {
        public int Id { get; set; }
        public string? Username { get; set; }
        public byte[]? PasswordHash { get; set; }
        public byte[]? PasswordSalt { get; set; }
        public Roles Role { get; set; }

        // One-to-Many with PersonalInformation
        public ICollection<PersonalInformation>? PersonalInformations { get; set; }
    }
}
