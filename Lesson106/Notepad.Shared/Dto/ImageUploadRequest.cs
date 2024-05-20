using Microsoft.AspNetCore.Http;
using Notepad.Shared.Attributes;

namespace Notepad.Shared.Dto
{
    public class ImageUploadRequest
    {
        [MaxFileSize(5 * 1024 * 1024)]
        [AllowedExtensions([".png", ".gif", ".jpeg", ".jpg"])]
        public required IFormFile Image { get; set; }
    }
}