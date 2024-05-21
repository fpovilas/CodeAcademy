using Notepad.Repository.Model;

namespace Notepad.Repository.Repository.Interface
{
    public interface INoteImageRepository
    {
        public T? GetImage<T>(int id) where T : class;
        public void UploadImage(NoteImage image);
        public void UploadThumbnail(NoteImageThumbnail thumbnail);
    }
}
