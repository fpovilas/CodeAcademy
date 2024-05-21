using Notepad.Repository.Database;
using Notepad.Repository.Model;
using Notepad.Repository.Repository.Interface;

namespace Notepad.Repository.Repository
{
    public class NoteImageRepository(NotepadDbContext context) : INoteImageRepository
    {
        public void UploadImage(NoteImage image)
        {
            context.NoteImages.Add(image);
            context.SaveChanges();
        }

        public void UploadThumbnail(NoteImageThumbnail thumbnail)
        {
            context.NoteImageThumbnails.Add(thumbnail);
            context.SaveChanges();
        }

        public T? GetImage<T>(int id) where T : class
        {
            if (typeof(T) == typeof(NoteImage))
            {
                return context.NoteImages.FirstOrDefault(context => context.Id == id) as T;
            }
            else if (typeof(T) == typeof(NoteImageThumbnail))
            {
                return context.NoteImageThumbnails.FirstOrDefault(context => context.Id == id) as T;
            }
            else
            {
                throw new InvalidOperationException("Unsupported type.");
            }
        }
    }
}
