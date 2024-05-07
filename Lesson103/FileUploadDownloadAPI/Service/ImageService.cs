using FileUploadDownloadAPI.Model;
using FileUploadDownloadAPI.Repository.Interface;
using FileUploadDownloadAPI.Service.Interface;

namespace FileUploadDownloadAPI.Service
{
    public class ImageService(IImageRepository imageRepository) : IImageService
    {
        public Image GetImage(Guid id) =>
            imageRepository.GetImage(id);
    }
}
