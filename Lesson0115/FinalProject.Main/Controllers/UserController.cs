using FinalProject.Business.Service.Interface;
using FinalProject.Shared.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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

        // GET: api/User/All
        [Authorize(Roles = "Admin")]
        [HttpGet("AdminGetAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public ActionResult<IEnumerable<UserAdminDTO>> GetALL()
        {
            var userClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role);

            try
            {
                if (userClaim is null)
                { return BadRequest("Please log in."); }

                return Ok(userService.GetAll(userClaim));
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }
        }

        // GET: api/User/GetById/5
        [HttpGet("AdminGetById/{idU}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public ActionResult<UserAdminDTO> GetById(int idU)
        {
            try
            {
                var userClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role);

                if (userClaim is null)
                { return BadRequest("Please log in."); }

                return Ok(userService.Get(idU, userClaim));
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        // DELETE: api/User/Delete
        [HttpDelete("AdminDelete/{idU}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult DeletePersonalInformation(int idU)
        {
            string deletedUsername = string.Empty;
            try
            {
                var userClaim = User.Claims;
                if (userClaim is not null)
                { deletedUsername = userService.Delete(idU, userClaim); }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok($"Successfully deleted {deletedUsername}");
        }
    }
}