using Notepad.Repository.Model;
using Notepad.Repository.Repository.Interface;
using Notepad.Service.Service.Interface;
using Notepad.Shared.Dto;

namespace Notepad.Service.Service
{
    public class NoteService(INoteRepository noteRepository) : INoteService
    {
        public bool Create(NoteDto note)
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

                noteRepository.Create(newNote);
            }
            catch
            {
                return false;
            }

            return true;
        }

        public ICollection<Tag> ConvertToTag(ICollection<TagDto> tagDtos)
        {
            ICollection<Tag> tags = [];
            foreach (TagDto tagDto in tagDtos)
            {
                Tag tag = new()
                {
                    Name = tagDto.TagName!
                };

                tags.Add(tag);
            }

            return tags;
        }
    }
}