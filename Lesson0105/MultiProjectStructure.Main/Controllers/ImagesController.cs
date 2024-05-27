using Microsoft.AspNetCore.Mvc;
using MultiProjectStructure.BusinessLogic.Dto;
using MultiProjectStructure.BusinessLogic.Service.Interface;

namespace MultiProjectStructure.Main.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController(IPhotoService photoService) : ControllerBase
    {
        // POST: api/Images/Upload
        [HttpPost("Upload")]
        public ActionResult UploadImage([FromForm] ImageUploadRequest request) =>
            photoService.UploadImageAndThumbnail(request.Image) ? Ok() : StatusCode(StatusCodes.Status418ImATeapot);

        // POST: api/Images/UploadBulk
        [HttpPost("UploadBulk")]
        public ActionResult UploadImageBulk([FromForm] BulkImageUploadRequest requests)
        {
            return photoService.UploadBulkImageAndThmubnails(requests) ? Ok() : StatusCode(StatusCodes.Status418ImATeapot);
        }

        // GET: api/Images/Download
        [HttpGet("Download")]
        public ActionResult DownloadImage([FromQuery] Guid guid)
        {
            var image = photoService.GetImage(guid);
            return File(image.ImageData, $"{image.ContentType}");
        }

        // GET: api/Images/DownloadThumbnail
        [HttpGet("DownloadThumbnail")]
        public ActionResult DownloadImageThumbnail([FromQuery] Guid guid)
        {
            var thumbnail = photoService.GetImageThumbnail(guid);

            return File(thumbnail.ImageData, $"{thumbnail.ContentType}");
        }
    }
}