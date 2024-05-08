using FileUploadDownloadAPI.Model;
using FileUploadDownloadAPI.Model.Dto;
using Microsoft.AspNetCore.Mvc;

namespace FileUploadDownloadAPI.Service.Interface
{
    public interface IImageService
    {
       public CustomImage GetImage(Guid id);
       public CustomImageThumbnail GetImageThumbnail(Guid id);
       public bool UploadBulkImageAndThmubnails(BulkImageUploadRequest requests);
       public bool UploadImageAndThumbnail(IFormFile request);
    }
}