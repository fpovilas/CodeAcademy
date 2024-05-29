using FinalProject.Business.Service.Interface;
using FinalProject.Shared.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Main.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(IUserService userService) : ControllerBase
    {
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost("SignUp")]
        public ActionResult<SignUpUserDTO> SignUp([FromForm] SignUpUserDTO user)
        {
            try
            {
                if (user.CheckUsername() && user.CheckPassword())
                {
                    userService.SignUp(user);
                }
            }
            catch (Exception ex)
            { return BadRequest(ex.Message); }

            return Ok(user.Username);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost("LogIn")]
        public ActionResult LogIn([FromForm] SignUpUserDTO user)
        {
            string jwt;
            try
            {
                jwt = userService.LogIn(user);
            }
            catch (Exception ex)
            { return BadRequest(ex.Message); }

            return Ok(jwt);
        }
    }
}