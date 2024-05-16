using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Notepad.Repository.Model;
using Notepad.Service.Service.Interface;
using Notepad.Shared.Dto;

namespace Notepad.Main.Controller
{
    [Route("/[controller]")]
    [ApiController]
    public class TagController(ITagService tagService) : ControllerBase
    {
        [Authorize]
        [HttpPost("Create")]
        [ProducesResponseType(200)] // OK
        [ProducesResponseType(400)] // Bad Request
        public ActionResult<TagDto> Create(string tagName)
        {
            if (!tagService.Create(tagName))
            { return BadRequest($"Given data (\"{tagName}\") is wrong."); }

            return Ok(new TagDto { TagName = tagName });
        }

        [Authorize]
        [HttpPost("Edit")]
        [ProducesResponseType(200)] // OK
        [ProducesResponseType(400)] // Bad Request
        public ActionResult Edit(int tagID, string newTagName)
        {
            if (!tagService.Edit(tagID, newTagName))
            { return BadRequest($"Given data (\"ID: {tagID} - New Tag name: {newTagName}\") is wrong."); }

            return Ok("Success");
        }

        [Authorize]
        [HttpPost("Delete")]
        [ProducesResponseType(200)] // OK
        [ProducesResponseType(400)] // Bad Request
        public ActionResult Delete(int tagID)
        {
            if (!tagService.Delete(tagID))
            { return BadRequest($"Entry with ID: {tagID} does not exist"); }

            return Ok("Entry deleted");
        }

        [Authorize]
        [HttpPost("Get")]
        [ProducesResponseType(200)] // OK
        [ProducesResponseType(400)] // Bad Request
        public ActionResult<Tag> Get(int tagID)
        {
            if (!tagService.Get(tagID, out Tag tag))
            { return BadRequest($"Entry with ID: {tagID} does not exist"); }

            return Ok(tag);
        }
    }
}