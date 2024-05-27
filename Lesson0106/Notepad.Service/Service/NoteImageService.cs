using Microsoft.AspNetCore.Http;
using Notepad.Repository.Model;
using Notepad.Repository.Repository.Interface;
using Notepad.Service.Helper;
using Notepad.Service.Service.Interface;

namespace Notepad.Service.Service
{
    public class NoteImageService(INoteImageRepository noteImageRepository) : INoteImageService
    {
        private readonly string noteImagePath = @"./NoteImages";
        private readonly string noteImageThumbnailPath = @"./NoteImages/Thumbnails";

        public bool UploadImageAndThumbnail(IFormFile request, Note note, out int noteImageId)
        {
            noteImageId = 0;
            try
            {
                using var memoryStream = new MemoryStream();
                request.CopyTo(memoryStream);
                var imageBytes = memoryStream.ToArray();

                string noteImageName = request.FileName[..request.FileName.IndexOf('.')];
                string currentTime = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
                string noteImageExtension = Path.GetExtension(request.FileName).Trim('.');

                string noteImageFilePath = $"{noteImagePath}/{noteImageName}_{currentTime}.{noteImageExtension}";
                string noteImageThumbnailFilePath = $"{noteImageThumbnailPath}/Thumb_{noteImageName}_{currentTime}.png";

                if (!Directory.Exists(noteImagePath))
                { Directory.CreateDirectory(noteImagePath); }

                if (!Directory.Exists(noteImageThumbnailPath))
                { Directory.CreateDirectory(noteImageThumbnailPath); }

                // Create image thumbnail
                NoteImageThumbnail thumbnail = new()
                {
                    Name = request.FileName,
                    ContentType = request.ContentType,
                    PictureUrl = noteImageThumbnailFilePath,
                };

                // Create image
                NoteImage image = new()
                {
                    Name = request.FileName,
                    ContentType = request.ContentType,
                    PictureUrl = noteImageFilePath,
                    Note = note,
                    NoteImageThumbnail = thumbnail
                };

                noteImageRepository.UploadImage(image);

                var imgData = ImageHelper.Resize(imageBytes, 120, 120);
                ImageHelper.SaveNoteImageThumbnail(noteImageThumbnailFilePath, imgData);
                File.WriteAllBytes(noteImageFilePath, imageBytes);

                return true;
            }
            catch { return false; }
        }

        public bool GetImage(int id, out string msg, out NoteImage? noteImage)
        {
            noteImage = noteImageRepository.GetImage<NoteImage>(id);
            msg = string.Empty;

            if (noteImage is null)
            {
                msg = "Image not found.";
                return false;
            }

            if (!File.Exists(noteImage.PictureUrl))
            {
                msg = "File does not exist on disk.";
                return false;
            }

            return true;
        }

        public bool GetImageThumbnail(int id, out string msg, out NoteImageThumbnail noteImageThumbnail)
        {
            noteImageThumbnail = noteImageRepository.GetImage<NoteImageThumbnail>(id)!;
            msg = string.Empty;

            if (noteImageThumbnail is null)
            {
                msg = "Image not found.";
                return false;
            }

            if (!File.Exists(noteImageThumbnail.PictureUrl))
            {
                msg = "File does not exist on disk.";
                return false;
            }

            return true;
        }
    }
}
