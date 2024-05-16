using System.ComponentModel.DataAnnotations.Schema;

namespace Notepad.Repository.Model
{
    public class NoteImage
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string ContentType { get; set; }
        public required string PictureUrl { get; set; }

        // One-to-One relationship with NoteImage entity (NoteImageThumbnail can have one NoteImage)
        [ForeignKey(nameof(Note))]
        public int NoteId { get; set; }
        public virtual Note? Note { get; set; }
    }
}
