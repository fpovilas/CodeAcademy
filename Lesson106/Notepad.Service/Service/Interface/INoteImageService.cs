using Microsoft.AspNetCore.Http;
using Notepad.Repository.Model;

namespace Notepad.Service.Service.Interface
{
    public interface INoteImageService
    {
        public bool GetImage(int id, out string msg, out NoteImage? noteImage);
        public bool GetImageThumbnail(int id, out string msg, out NoteImageThumbnail noteImageThumbnail);
        public bool UploadImageAndThumbnail(IFormFile request);
    }
}
