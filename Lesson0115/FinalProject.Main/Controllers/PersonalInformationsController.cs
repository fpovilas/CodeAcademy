using FinalProject.Business.Service.Interface;
using FinalProject.Database.Database;
using FinalProject.Database.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace FinalProject.Main.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PersonalInformationsController(PRSDbContext context, IPersonalInfoService personalInfoService) : ControllerBase
    {
        // GET: api/PersonalInformations/All
        [HttpGet("All")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<IEnumerable<PersonalInformation>>> GetPersonalInformations()
        {
            var username = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;

            return await context.PersonalInformations.ToListAsync();
        }

        // GET: api/PersonalInformations/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<PersonalInformation>> GetPersonalInformation(int id)
        {
            var personalInformation = await context.PersonalInformations.FindAsync(id);

            if (personalInformation == null)
            {
                return NotFound();
            }

            return personalInformation;
        }

        // PUT: api/PersonalInformations/5
        // To protect from over posting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> PutPersonalInformation(int id, PersonalInformation personalInformation)
        {
            if (id != personalInformation.Id)
            {
                return BadRequest();
            }

            context.Entry(personalInformation).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonalInformationExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/PersonalInformations
        // To protect from over posting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<PersonalInformation>> PostPersonalInformation(PersonalInformation personalInformation)
        {
            context.PersonalInformations.Add(personalInformation);
            await context.SaveChangesAsync();

            return CreatedAtAction("GetPersonalInformation", new { id = personalInformation.Id }, personalInformation);
        }

        // DELETE: api/PersonalInformations/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> DeletePersonalInformation(int id)
        {
            var personalInformation = await context.PersonalInformations.FindAsync(id);
            if (personalInformation == null)
            {
                return NotFound();
            }

            context.PersonalInformations.Remove(personalInformation);
            await context.SaveChangesAsync();

            return NoContent();
        }

        private bool PersonalInformationExists(int id)
        {
            return context.PersonalInformations.Any(e => e.Id == id);
        }
    }
}
