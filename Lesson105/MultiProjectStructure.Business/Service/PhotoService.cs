using Microsoft.AspNetCore.Http;
using MultiProjectStructure.BusinessLogic.Dto;
using MultiProjectStructure.BusinessLogic.Helper;
using MultiProjectStructure.BusinessLogic.Service.Interface;
using MultiProjectStructure.Database.Entities;
using MultiProjectStructure.Database.Repository.Interface;

namespace MultiProjectStructure.BusinessLogic.Service
{
    public class PhotoService(IPhotoRepository photoRepository) : IPhotoService
    {
        public CustomImage GetImage(Guid id) =>
            photoRepository.GetImage(id);

        public CustomImageThumbnail GetImageThumbnail(Guid id) =>
            photoRepository.GetImageThumbnail(id);

        public bool UploadImageAndThumbnail(IFormFile request)
        {
            try
            {
                using var memoryStream = new MemoryStream();
                request.CopyTo(memoryStream);
                var imageBytes = memoryStream.ToArray();
                // Create image
                CustomImage image = new()
                {
                    Name = request.FileName,
                    ContentType = request.ContentType,
                    ImageData = imageBytes
                };

                // Create image thumbnail
                CustomImageThumbnail thumbnail = new()
                {
                    Name = request.FileName,
                    ContentType = request.ContentType,
                    ImageData = ImageHelper.Resize(imageBytes, 120, 120),
                    CustomImage = image
                };

                photoRepository.UploadImage(image);
                photoRepository.UploadThumbnail(thumbnail);

                return true;
            }
            catch { return false; }
        }

        public bool UploadBulkImageAndThmubnails(BulkImageUploadRequest requests)
        {
            List<bool> uploadSuccesses = [];
            foreach (var request in requests.Images)
            {
                uploadSuccesses.Add(UploadImageAndThumbnail(request));
            }

            if (uploadSuccesses.Count == 0)
                return false;

            return !(uploadSuccesses.Any(b => b == false));
        }
    }
}