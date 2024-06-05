using FinalProject.Shared.Attributes;
using Microsoft.AspNetCore.Http;

namespace FinalProject.Shared.DTOs
{
    public class ImageUpdateUploadRequest
    {
        [MaxFileSize(5 * 1024 * 1024)]
        [AllowedExtensions([".png", ".gif", ".jpeg", ".jpg"])]
        public IFormFile? Image { get; set; }
    }
}