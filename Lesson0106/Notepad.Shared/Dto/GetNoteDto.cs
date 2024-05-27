using Notepad.Repository.Model;

namespace Notepad.Shared.Dto
{
    public class GetNoteDto
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public ICollection<string>? Tags { get; set; }
        public ImageBaseDto? ImageBase { get; set; }
    }
}