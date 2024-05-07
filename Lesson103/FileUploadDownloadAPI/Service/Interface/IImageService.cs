using FileUploadDownloadAPI.Model;

namespace FileUploadDownloadAPI.Service.Interface
{
    public interface IImageService
    {
       public Image GetImage(Guid id);
    }
}