using FinalProject.Shared.Attributes;
using Microsoft.AspNetCore.Http;

namespace FinalProject.Shared.DTOs
{
    public class ImageUploadRequest
    {
        [MaxFileSize(5 * 1024 * 1024)]
        [AllowedExtensions([".png", ".gif", ".jpeg", ".jpg"])]
        public required IFormFile Image { get; set; }
    }
}