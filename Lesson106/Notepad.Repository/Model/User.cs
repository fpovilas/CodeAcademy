namespace Notepad.Repository.Model
{
    public class User
    {
        public int Id { get; set; }
        public string? Username { get; set; }
        public byte[]? PasswordHash { get; set; }
        public byte[]? PasswordSalt { get; set; }
        public string? Role { get; set; }

        // One-to-many relationship with Note entity (User can have many Notes)
        public ICollection<Note>? Notes { get; set; }
    }
}