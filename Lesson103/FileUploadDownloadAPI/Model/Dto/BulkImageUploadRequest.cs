using FileUploadDownloadAPI.Attributes;

namespace FileUploadDownloadAPI.Model.Dto
{
    public class BulkImageUploadRequest
    {
        [MaxFileSize(5 * 1024 * 1024)]
        [AllowedExtensions([".png", ".gif", ".jpeg", ".jpg"])]
        public required List<IFormFile> Images { get; set; }
    }
}