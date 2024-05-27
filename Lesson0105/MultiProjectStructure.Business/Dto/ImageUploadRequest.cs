using Microsoft.AspNetCore.Http;
using MultiProjectStructure.BusinessLogic.Attributes;

namespace MultiProjectStructure.BusinessLogic.Dto
{
    public class ImageUploadRequest
    {
        [MaxFileSize(5 * 1024 * 1024)]
        [AllowedExtensions([".png", ".gif", ".jpeg", ".jpg"])]
        public required IFormFile Image { get; set; }
    }
}