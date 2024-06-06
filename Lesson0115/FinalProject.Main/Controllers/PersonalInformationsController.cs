using FinalProject.Business.Service.Interface;
using FinalProject.Shared.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FinalProject.Main.Controllers
{
    [Authorize(Roles = "User, Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class PersonalInformationsController(IPersonalInfoService personalInfoService) : ControllerBase
    {
        // GET: api/PersonalInformations/All
        [HttpGet("All")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public ActionResult<IEnumerable<PersonalInformationDTO>> GetALL()
        {
            var username = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;

            try
            {
                if (string.IsNullOrEmpty(username))
                {
                    return BadRequest("Please log in.");
                }
                return Ok(personalInfoService.GetAll(username));
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }
        }

        // GET: api/PersonalInformations/5
        [HttpGet("GetById/{idPI}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public ActionResult<PersonalInformationWithIdDTO?> GetById(int idPI)
        {
            try
            {
                var username = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;

                if (string.IsNullOrEmpty(username))
                { return BadRequest("Please log in."); }
                var personalInfo = personalInfoService.Get(idPI, username);

                return Ok(personalInfo);
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        // PUT: api/PersonalInformations/AddPersonalInformation
        [HttpPost("AddPersonalInformation")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult PutPersonalInformation([FromForm] PersonalInformationDTO personalInformation, [FromForm] ImageUploadRequest request)
        {
            var username = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;

            try
            {
                if (personalInformation is not null && request is not null)
                {
                    personalInfoService.Put(personalInformation, request.Image, username);
                    return Ok(new { personalInformation });
                }
                return BadRequest("Not all fields are filled");
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }
        }

        // POST: api/PersonalInformations
        [HttpPatch("UpdatePersonalInformation")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public ActionResult<PersonalInformationUpdateDTO> UpdatePersonalInformation([FromForm] PersonalInformationUpdateDTO personalInformation, [FromForm] ImageUpdateUploadRequest request, int idPI)
        {
            try
            {
                var username = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;

                if (string.IsNullOrEmpty(username))
                { return BadRequest("Please log in."); }

                personalInfoService.Update(personalInformation, request.Image!, idPI, username);
            }
            catch (Exception ex) { return BadRequest(ex.Message); }

            return Ok();
        }

        // DELETE: api/PersonalInformations/Delete
        [HttpDelete("Delete/{idPI}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Delete(int idPI)
        {
            var username = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;
            try
            {
                if (!string.IsNullOrEmpty(username))
                { personalInfoService.Delete(idPI, username); }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok("Successfully deleted");
        }

        // DELETE: api/PersonalInformations/AdminDelete
        [HttpDelete("AdminDelete/{idPI}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult AdminDelete(int idPI)
        {
            var userClaim = User.Claims;
            string user;
            PersonalInformationAdminDTO? deletedUserPi;

            try
            {
                user = personalInfoService.AdminDelete(idPI, userClaim, out deletedUserPi);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(new
            {
                Message = $"Successfully deleted users {user} personal info",
                DeletedPersonalInfo = deletedUserPi
            });
        }

        // GET: api/PersonalInformations/DownloadProfilePicture
        [HttpGet("DownloadProfilePicture")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public ActionResult DownloadProfilePicture(int idPI)
        {
            var username = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;
            try
            {
                if (string.IsNullOrEmpty(username))
                { return BadRequest("Please log in."); }
                if (!personalInfoService.GetProfilePicture(idPI, username, out string msg, out string profilePicturePath))
                { return BadRequest(msg); }

                FileStream fileStream = new(profilePicturePath, FileMode.Open, FileAccess.Read);
                int startOfName = profilePicturePath.LastIndexOf('/') + 1;
                int endOfName = profilePicturePath.Length - startOfName - (profilePicturePath.Length - profilePicturePath.LastIndexOf('.'));
                string profilePictureName = profilePicturePath.Substring(startOfName, endOfName);
                return File(fileStream, "image/jpeg", profilePictureName);
            }
            catch (Exception ex)
            { return BadRequest(ex.Message); }
        }
    }
}