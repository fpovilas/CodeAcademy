using Microsoft.AspNetCore.Mvc;
using Notepad.Repository.Model;
using Notepad.Service.Service.Interface;
using Notepad.Shared.Dto;

namespace Notepad.Main.Controller
{
    [Route("[controller]")]
    [ApiController]
    public class NoteImageController(INoteImageService noteImageService) : ControllerBase
    {
        // POST: /Images/Upload
        [HttpPost("Upload")]
        public IActionResult UploadImage([FromForm] ImageUploadRequest request) =>
            noteImageService.UploadImageAndThumbnail(request.Image) ? Ok() : StatusCode(StatusCodes.Status400BadRequest);

        // GET: /Images/Download
        [HttpGet("Download")]
        public ActionResult DownloadImage([FromQuery] int id)
        {
            if (!noteImageService.GetImage(id, out string msg, out NoteImage noteImage))
            { return BadRequest(msg); }

            FileStream fileStream = new(noteImage.PictureUrl, FileMode.Open, FileAccess.Read);
            return File(fileStream, noteImage.ContentType, noteImage.Name);
        }

        // GET: /Images/Download
        [HttpGet("DownloadThumbnail")]
        public ActionResult DownloadImageThumbnail([FromQuery] int id)
        {
            if (!noteImageService.GetImageThumbnail(id, out string msg, out NoteImageThumbnail noteImageThumbnail))
            { return BadRequest(msg); }

            FileStream fileStream = new(noteImageThumbnail.PictureUrl, FileMode.Open, FileAccess.Read);
            return File(fileStream, noteImageThumbnail.ContentType, noteImageThumbnail.Name);
        }
    }
}
