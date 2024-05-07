using FileUploadDownloadAPI.Attributes;

namespace FileUploadDownloadAPI.Model.Dto
{
    public class ImageUploadRequest
    {
        [MaxFileSize(5 * 1024 * 1024)]
        [AllowedExtensions([".png", ".gif", ".jpeg", ".jpg"])]
        public required IFormFile Image { get; set; }
    }
}