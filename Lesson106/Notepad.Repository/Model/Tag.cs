using System.ComponentModel.DataAnnotations.Schema;

namespace Notepad.Repository.Model
{
    public class Tag
    {
        public int Id { get; set; }
        public required string Name { get; set; }

        // Relationship pointer many to many (Notes can have many Tags)
        public ICollection<Note>? Notes { get; set; }
    }
}
