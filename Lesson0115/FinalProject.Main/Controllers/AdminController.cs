using FinalProject.Business.Service.Interface;
using FinalProject.Shared.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FinalProject.Main.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController(IAdminService adminService) : ControllerBase
    {
        // GET: api/PersonalInformations/All
        [HttpGet("All")]
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

                return Ok(adminService.GetAll(userClaim));
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }
        }

        // GET: api/PersonalInformations/5
        [HttpGet("GetById/{idU}")]
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

                return Ok(adminService.Get(idU, userClaim));
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        // DELETE: api/PersonalInformations/Delete
        [HttpDelete("Delete/{idU}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult DeletePersonalInformation(int idU)
        {
            string deletedUsername;
            try
            {
                var userClaim = User.Claims;
                if (userClaim is not null)
                { deletedUsername = adminService.Delete(idU, userClaim); }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok("Successfully deleted");
        }
    }
}