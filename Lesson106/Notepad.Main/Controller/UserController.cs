using Microsoft.AspNetCore.Mvc;
using Notepad.Service.Service.Interface;
using Notepad.Shared.Dto;

namespace Notepad.Main.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(INoteService noteService) : ControllerBase
    {
        //[HttpPost("Register")]
        //public ActionResult<UserDto> Register(string username, string password)
        //{
        //    if(!noteService.Register(username, password, out userDto))
        //        return BadRequest();

        //    return Ok(userDto);
        //}
    }
}
