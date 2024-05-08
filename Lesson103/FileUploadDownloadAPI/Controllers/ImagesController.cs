using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FileUploadDownloadAPI.Database;
using FileUploadDownloadAPI.Model;
using FileUploadDownloadAPI.Model.Dto;
using FileUploadDownloadAPI.Service.Interface;
using System.IO.Compression;

namespace FileUploadDownloadAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController(ImageDbContext context, IImageService imageService) : ControllerBase
    {
        // POST: api/Images/Upload
        [HttpPost("Upload")]
        public ActionResult UploadImage([FromForm] ImageUploadRequest request) =>
            imageService.UploadImageAndThumbnail(request.Image) ? Ok() : StatusCode(StatusCodes.Status418ImATeapot);

        // POST: api/Images/UploadBulk
        [HttpPost("UploadBulk")]
        public ActionResult UploadImageBulk([FromForm] BulkImageUploadRequest requests)
        {
            return imageService.UploadBulkImageAndThmubnails(requests) ? Ok() : StatusCode(StatusCodes.Status418ImATeapot);
        }

        // GET: api/Images/Download
        [HttpGet("Download")]
        public ActionResult DownloadImage([FromQuery] Guid guid)
        {
            var image = imageService.GetImage(guid);
            return File(image.ImageData, $"{image.ContentType}");
        }

        // GET: api/Images/DownloadThumbnail
        [HttpGet("DownloadThumbnail")]
        public ActionResult DownloadImageThumbnail([FromQuery] Guid guid)
        {
            var thumbnail = imageService.GetImageThumbnail(guid);

            return File(thumbnail.ImageData, $"{thumbnail.ContentType}");
        }

        // GET: api/Images/Get
        [HttpGet("Get")]
        public async Task<ActionResult<IEnumerable<CustomImage>>> GetImages()
        {
            return await context.Images.ToListAsync();
        }
    }
}