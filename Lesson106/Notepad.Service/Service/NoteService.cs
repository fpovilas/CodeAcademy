﻿using Microsoft.AspNetCore.Http;
using Notepad.Repository.Model;
using Notepad.Repository.Repository.Interface;
using Notepad.Service.Service.Interface;
using Notepad.Shared.Dto;

namespace Notepad.Service.Service
{
    public class NoteService(INoteRepository noteRepository, INoteImageService noteImageService, IUserService userService) : INoteService
    {
        public bool Create(NoteDto note, IFormFile? image, string username)
        {
            try
            {
                if (note is null)
                { return false; }

                Note newNote = new()
                {
                    Description = note.Description!,
                    Tags = ConvertToTag(note.Tags ?? []),
                    Title = note.Title!,
                    UserId = userService.GetIdByUsername(username)
                };

                if (image is not null)
                {
                    if (!noteImageService.UploadImageAndThumbnail(image, newNote, out int noteImageId))
                    { return false; }
                }
                else
                { noteRepository.Create(newNote); }
            }
            catch
            {
                return false;
            }

            return true;
        }

        public List<GetNoteDto> GetAll(string username)
        {
            var user = userService.GetByUsername(username) ?? throw new Exception("User is null");
            var notes = noteRepository.GetAll(user.Id);
            List<GetNoteDto> noteDtos = [];

            foreach (var note in notes)
            {
                noteDtos.Add(Convert(note));
            }

            return noteDtos;
        }

        public bool DeleteByID(int id, string username, out GetNoteDto note)
        {
            note = new();

            var user = userService.GetByUsername(username);

            if (user is null)
            { return false; }

            if (user.Notes?.Count == 0)
            { return false; }

            var realNote = user.Notes?.FirstOrDefault(n => n.User!.Equals(user));

            if (realNote is null)
            { return false; }

            note = Convert(realNote);
            noteRepository.Remove(realNote);
            return true;
        }

        public ICollection<Tag> ConvertToTag(ICollection<string> tagDtos)
        {
            ICollection<Tag> tags = [];
            foreach (string tagDto in tagDtos)
            {
                Tag tag = new()
                {
                    Name = tagDto
                };

                tags.Add(tag);
            }

            return tags;
        }

        public static GetNoteDto Convert(Note note)
        {
            GetNoteDto noteDto = new();

            if (note.NoteImage is not null)
            {
                var imageBase = new ImageBaseDto()
                {
                    ContentType = note.NoteImage!.ContentType,
                    Name = note.NoteImage.Name,
                    PictureUrl = note.NoteImage.PictureUrl
                };

                noteDto = new()
                {
                    Title = note.Title,
                    Description = note.Description,
                    Tags = note.Tags?.Select(t => t.Name).ToList(),
                    ImageBase = imageBase
                };
            }
            else
            {
                noteDto = new()
                {
                    Title = note.Title,
                    Description = note.Description,
                    Tags = note.Tags?.Select(t => t.Name).ToList()
                };

            }

            return noteDto;
        }
    }
}