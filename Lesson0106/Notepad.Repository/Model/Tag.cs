namespace Notepad.Repository.Model
{
    public class Tag
    {
        public int Id { get; set; }
        public required string Name { get; set; }

        // Many-to-many relationship with Note entity (Notes can have many Tags)
        public ICollection<Note>? Notes { get; set; }
    }
}