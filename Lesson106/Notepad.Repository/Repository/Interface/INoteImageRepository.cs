using Notepad.Repository.Model;

namespace Notepad.Repository.Repository.Interface
{
    public interface INoteImageRepository
    {
        public T? GetImage<T>(int id) where T : class;
        public void UpdateImage(NoteImage noteImage);
        public int UploadImage(NoteImage image);
        public int UploadThumbnail(NoteImageThumbnail thumbnail);
    }
}
