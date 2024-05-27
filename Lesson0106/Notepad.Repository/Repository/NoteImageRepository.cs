using Notepad.Repository.Database;
using Notepad.Repository.Model;
using Notepad.Repository.Repository.Interface;

namespace Notepad.Repository.Repository
{
    public class NoteImageRepository(NotepadDbContext context) : INoteImageRepository
    {
        public int UploadImage(NoteImage image)
        {
            context.NoteImages.Add(image);
            context.SaveChanges();

            int id = image.Id;

            return id;
        }

        public int UploadThumbnail(NoteImageThumbnail thumbnail)
        {
            context.NoteImageThumbnails.Add(thumbnail);
            context.SaveChanges();

            int id = thumbnail.Id;

            return id;
        }

        public void UpdateImage(NoteImage noteImage)
        {
            context.Update(noteImage);
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
