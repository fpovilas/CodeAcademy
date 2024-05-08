using FileUploadDownloadAPI.Helper;
using FileUploadDownloadAPI.Model;
using FileUploadDownloadAPI.Model.Dto;
using FileUploadDownloadAPI.Repository.Interface;
using FileUploadDownloadAPI.Service.Interface;

namespace FileUploadDownloadAPI.Service
{
    public class ImageService(IImageRepository imageRepository) : IImageService
    {
        public CustomImage GetImage(Guid id) =>
            imageRepository.GetImage(id);

        public CustomImageThumbnail GetImageThumbnail(Guid id) =>
            imageRepository.GetImageThumbnail(id);

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

                imageRepository.UploadImage(image);
                imageRepository.UploadThumbnail(thumbnail);

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
