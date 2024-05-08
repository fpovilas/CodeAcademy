using FileUploadDownloadAPI.Model;

namespace FileUploadDownloadAPI.Repository.Interface
{
    public interface IImageRepository
    {
        public CustomImage GetImage(Guid guid);
        public CustomImageThumbnail GetImageThumbnail(Guid guid);
        public void UploadImage(CustomImage image);
        public void UploadThumbnail(CustomImageThumbnail thumbnail);
    }
}