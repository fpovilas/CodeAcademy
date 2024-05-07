using FileUploadDownloadAPI.Model;

namespace FileUploadDownloadAPI.Repository.Interface
{
    public interface IImageRepository
    {
        public Image GetImage(Guid guid);
    }
}