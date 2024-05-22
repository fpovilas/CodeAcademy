using Microsoft.AspNetCore.Http;
using Notepad.Repository.Model;
using Notepad.Repository.Repository.Interface;
using Notepad.Service.Service.Interface;
using Notepad.Shared.Dto;

namespace Notepad.Service.Service
{
    public class NoteService(INoteRepository noteRepository, INoteImageService noteImageService) : INoteService
    {
        public bool Create(NoteDto note, IFormFile? image)
        {
            try
            {
                if (note is null)
                { return false; }

                Note newNote = new()
                {
                    Description = note.Description,
                    Tags = ConvertToTag(note.Tags ?? []),
                    Title = note.Title,
                    UserId = note.UserId
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
    }
}