using Microsoft.AspNetCore.Mvc;
using Notepad.Service.Service.Interface;
using Notepad.Shared.Dto;

namespace Notepad.Main.Controller
{
    [Route("/[controller]")]
    [ApiController]
    public class UserController(IUserService userService) : ControllerBase
    {
        [HttpPost("Register")]
        [ProducesResponseType(200)] // OK
        [ProducesResponseType(400)] // Bad Request
        public ActionResult<UserDto> Register(string username, string password)
        {
            if (!userService.Register(username, password, out UserDto userDto))
                return BadRequest();

            return Ok(userDto);
        }

        [HttpPost("LogIn")]
        [ProducesResponseType(200)] // OK
        [ProducesResponseType(400)] // Bad Request
        public ActionResult<string> LogIn(string username, string password)
        {
            if (!userService.LogIn(username, password, out string jwt))
                return BadRequest($"Bad data provided {username} {password}");

            return Ok(jwt);
        }
    }
}