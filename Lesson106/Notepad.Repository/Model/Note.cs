using System.ComponentModel.DataAnnotations.Schema;

namespace Notepad.Repository.Model
{
    public class Note
    {
        public required int Id { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }

        // Relationship pointer many to many (Notes can have many Tags)
        public ICollection<string>? Tags { get; set; }

        // Relationship pointer one to many (User can have many Notes)
        [ForeignKey(nameof(User))]
        public int? UserId { get; set; }
        public virtual User? User { get; set; }
    }
}
