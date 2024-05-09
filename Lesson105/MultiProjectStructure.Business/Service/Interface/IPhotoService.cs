using Microsoft.AspNetCore.Http;
using MultiProjectStructure.BusinessLogic.Dto;
using MultiProjectStructure.Database.Entities;

namespace MultiProjectStructure.BusinessLogic.Service.Interface
{
    public interface IPhotoService
    {
        CustomImage GetImage(Guid id);
        CustomImageThumbnail GetImageThumbnail(Guid id);
        bool UploadBulkImageAndThmubnails(BulkImageUploadRequest requests);
        bool UploadImageAndThumbnail(IFormFile request);
    }
}