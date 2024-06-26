﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Notepad.Service.Service.Interface;
using Notepad.Shared.Dto;
using System.Security.Claims;

namespace Notepad.Main.Controller
{
    [Route("[controller]")]
    [ApiController]
    public class NoteController(INoteService noteService) : ControllerBase
    {
        [Authorize]
        [HttpPost("Create")]
        [ProducesResponseType(200)] // OK
        [ProducesResponseType(400)] // Bad Request
        public ActionResult<GetNoteDto> Create([FromForm] NoteDto? note, [FromForm] ImageUploadRequest? request = null)
        {
            var username = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;

            if (note is null)
            { return BadRequest("Bad Request"); }

            if (username is not null)
            {
                if (!noteService.Create(note, request?.Image, username))
                { return BadRequest("Bad Request"); }
            }
            else { return BadRequest("Bad Request"); }

            return Ok(note);
        }

        [Authorize]
        [HttpGet("GetNotes")]
        [ProducesResponseType(200)] // OK
        [ProducesResponseType(400)] // Bad Request
        public ActionResult<List<GetNoteDto>> GetNotes()
        {
            var username = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;
            if (username is null)
            { return BadRequest("Something went wrong with parsing user data"); }

            List<GetNoteDto> notes = [];

            try
            {
                notes = noteService.GetAll(username);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(notes);
        }

        [Authorize]
        [HttpGet("Delete")]
        [ProducesResponseType(200)] // OK
        [ProducesResponseType(400)] // Bad Request
        public ActionResult<GetNoteDto> DeleteByID(int noteID)
        {
            var username = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;
            if (username is null)
            { return BadRequest("Something went wrong with parsing user data"); }

            if (!noteService.DeleteByID(noteID, username, out GetNoteDto note))
            { return BadRequest("Could not delete note"); }

            return Ok(note);
        }

        [Authorize]
        [HttpPut("Update")]
        [ProducesResponseType(200)] // OK
        [ProducesResponseType(400)] // Bad Request
        public ActionResult<GetNoteDto> Update([FromForm] int noteID, [FromForm] NoteDto? note, [FromForm] ImageUploadRequest? request = null)
        {
            var username = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;

            if (note is null)
            { return BadRequest("Bad Request"); }

            if (username is not null)
            {
                if (!noteService.Update(noteID, note, request?.Image, username))
                { return BadRequest("Bad Request"); }
            }
            else { return BadRequest("Bad Request"); }

            return Ok(note);
        }

        [Authorize]
        [HttpGet("GetByNoteName")]
        [ProducesResponseType(200)] // OK
        [ProducesResponseType(400)] // Bad Request
        public ActionResult<IEnumerable<GetNoteDto>> GetByNoteName(string noteTitle)
        {
            if (noteTitle is null)
            { return BadRequest("No property is given"); }

            var username = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;

            if (username is null)
            { return BadRequest("Please login"); }

            IEnumerable<GetNoteDto> notes = noteService
                .GetAll(username)
                .Where(n => n.Title!.Equals(noteTitle));

            if (!notes.Any())
            { return BadRequest($"Note with Title: \"{noteTitle}\" does not exists"); }
            else { return Ok(notes); }
        }

        [Authorize]
        [HttpGet("GetByTagName")]
        [ProducesResponseType(200)] // OK
        [ProducesResponseType(400)] // Bad Request
        public ActionResult<IEnumerable<GetNoteDto>> GetByTagName(string tagName)
        {
            if (tagName is null)
            { return BadRequest("No property is given"); }

            var username = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;

            if (username is null)
            { return BadRequest("Please login"); }

            IEnumerable<GetNoteDto> notes = noteService
                .GetAll(username)
                .Where(t => t.Tags!.Any(tn => tn.Equals(tagName, StringComparison.OrdinalIgnoreCase)));

            if (!notes.Any())
            { return BadRequest($"Note with Tag: \"{tagName}\" does not exists"); }
            else { return Ok(notes); }
        }
    }
}