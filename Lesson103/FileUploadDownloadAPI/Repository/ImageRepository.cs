using FileUploadDownloadAPI.Database;
using FileUploadDownloadAPI.Model;
using FileUploadDownloadAPI.Repository.Interface;

namespace FileUploadDownloadAPI.Repository
{
    public class ImageRepository(ImageDbContext context) : IImageRepository
    {
        public Image GetImage(Guid guid) =>
            context.Images.First(img => img.Equals(guid));
    }
}
