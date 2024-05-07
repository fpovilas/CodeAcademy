using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FileUploadDownloadAPI.Database;
using FileUploadDownloadAPI.Model;
using FileUploadDownloadAPI.Model.Dto;
using FileUploadDownloadAPI.Service.Interface;

namespace FileUploadDownloadAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController(ImageDbContext context, IImageService imageService) : ControllerBase
    {
        // POST: api/Images/Upload
        [HttpPost("Upload")]
        public ActionResult UploadImage([FromForm] ImageUploadRequest request)
        {
            using var memoryStream = new MemoryStream();
            request.Image.CopyTo(memoryStream);
            var imageBytes = memoryStream.ToArray();
            Image image = new()
            {
                Name = request.Image.Name,
                ContentType = request.Image.ContentType,
                ImageData = imageBytes,
                PictureUrl = request.Image.FileName
            };
            context.Images.Add(image);
            context.SaveChanges();
            return Ok();
        }

        // GET: api/Images/Download
        [HttpGet("Download")]
        public ActionResult DownloadImage([FromQuery] Guid guid)
        {
            var image = imageService.GetImage(guid);
            return File(image.ImageData, $"image/{image.ContentType}");
        }

        // GET: api/Images/Get
        [HttpGet("Get")]
        public async Task<ActionResult<IEnumerable<Image>>> GetImages()
        {
            return await context.Images.ToListAsync();
        }
    }
}
