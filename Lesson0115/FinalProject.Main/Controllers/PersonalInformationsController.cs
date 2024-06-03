using FinalProject.Business.Service.Interface;
using FinalProject.Database.Entity;
using FinalProject.Shared.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FinalProject.Main.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PersonalInformationsController(IPersonalInfoService personalInfoService) : ControllerBase
    {
        // GET: api/PersonalInformations/All
        [HttpGet("All")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public ActionResult<IEnumerable<PersonalInformation>> GetPersonalInformations()
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

        #region
        //// GET: api/PersonalInformations/5
        //[HttpGet("{id}")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status401Unauthorized)]
        //public async Task<ActionResult<PersonalInformation>> GetPersonalInformation(int id)
        //{
        //    var personalInformation = await context.PersonalInformations.FindAsync(id);

        //    if (personalInformation == null)
        //    {
        //        return NotFound();
        //    }

        //    return personalInformation;
        //}
        #endregion

        // PUT: api/PersonalInformations/AddPersonalInformation
        [HttpPut("AddPersonalInformation")]
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

        #region
        //// POST: api/PersonalInformations
        //// To protect from over posting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status401Unauthorized)]
        //public async Task<ActionResult<PersonalInformation>> PostPersonalInformation(PersonalInformation personalInformation)
        //{
        //    context.PersonalInformations.Add(personalInformation);
        //    await context.SaveChangesAsync();

        //    return CreatedAtAction("GetPersonalInformation", new { id = personalInformation.Id }, personalInformation);
        //}

        #endregion

        // DELETE: api/PersonalInformations/Delete
        [HttpDelete("Delete/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult DeletePersonalInformation(int id)
        {
            var username = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;
            try
            {
                if (!string.IsNullOrEmpty(username))
                { personalInfoService.Delete(id, username); }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok("Successfully deleted");
        }
    }
}