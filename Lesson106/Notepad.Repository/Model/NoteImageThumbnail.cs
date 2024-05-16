using System.ComponentModel.DataAnnotations.Schema;

namespace Notepad.Repository.Model
{
    public class NoteImageThumbnail
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string ContentType { get; set; }
        public required byte[] ImageData { get; set; }
        public required string PictureUrl { get; set; }

        // One-to-One relationship with NoteImage entity (NoteImageThumbnail can have one NoteImage)
        [ForeignKey(nameof(NoteImage))]
        public int NoteImageId { get; set; }
        public virtual NoteImage? NoteImage { get; set; }
    }
}
