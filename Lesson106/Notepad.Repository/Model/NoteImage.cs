using System.ComponentModel.DataAnnotations.Schema;

namespace Notepad.Repository.Model
{
    public class NoteImage : ImageBase
    {
        // One-to-One relationship with Note entity (NoteImage can have one Note)
        [ForeignKey(nameof(Note))]
        public int NoteId { get; set; }
        public virtual Note? Note { get; set; }

        // One-to-One relationship with NoteImageThumbnail entity (NoteImage can have one NoteImageThumbnail)
        //[ForeignKey(nameof(NoteImageThumbnail))]
        //public int NoteImageThumbnailId { get; set; }
        public virtual NoteImageThumbnail? NoteImageThumbnail { get; set; }
    }
}
