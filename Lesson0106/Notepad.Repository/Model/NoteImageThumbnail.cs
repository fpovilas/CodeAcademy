using System.ComponentModel.DataAnnotations.Schema;

namespace Notepad.Repository.Model
{
    public class NoteImageThumbnail : ImageBase
    {
        // One-to-One relationship with NoteImage entity (NoteImageThumbnail can have one NoteImage)
        [ForeignKey(nameof(NoteImage))]
        public int NoteImageId { get; set; }
        public virtual NoteImage? NoteImage { get; set; }
    }
}
