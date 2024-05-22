using Microsoft.AspNetCore.Mvc;
using Notepad.Service.Service.Interface;
using Notepad.Shared.Dto;

namespace Notepad.Main.Controller
{
    [Route("[controller]")]
    [ApiController]
    public class NoteController(INoteService noteService) : ControllerBase
    {
        [HttpPost("Create")]
        [ProducesResponseType(200)] // OK
        [ProducesResponseType(400)] // Bad Request
        public ActionResult<NoteDto> Create([FromForm] NoteDto? note, [FromForm] ImageUploadRequest request)
        {
            if (note is null)
            { return BadRequest("Bad Request"); }

            if (!noteService.Create(note, request.Image))
            { return BadRequest("Bad Request"); }

            return Ok(note);
        }
    }
}