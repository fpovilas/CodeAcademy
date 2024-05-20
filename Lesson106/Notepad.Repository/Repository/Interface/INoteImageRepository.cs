using Notepad.Repository.Model;

namespace Notepad.Repository.Repository.Interface
{
    public interface INoteImageRepository
    {
        public NoteImage? GetImage(int id);
        public void UploadImage(NoteImage image);
        public void UploadThumbnail(NoteImageThumbnail thumbnail);
    }
}
