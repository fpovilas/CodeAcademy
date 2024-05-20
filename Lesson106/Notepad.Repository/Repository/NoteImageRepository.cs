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

        public NoteImage? GetImage(int id)
        {
            return context.NoteImages.FirstOrDefault(x => x.Id == id);
        }
    }
}
