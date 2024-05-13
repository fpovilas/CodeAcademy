namespace Notepad.Repository.Model
{
    public class User
    {
        public int Id { get; set; }
        public required string Username { get; set; }
        public required byte[] PasswordHash { get; set; }
        public required byte[] PasswordSalt { get; set; }
        public required string Role { get; set; }

        // Relationship pointer one to many (User can have many Notes)
        public ICollection<Note>? Notes { get; set; }
    }
}
