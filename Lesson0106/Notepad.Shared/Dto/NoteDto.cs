namespace Notepad.Shared.Dto
{
    public class NoteDto
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public ICollection<string>? Tags { get; set; }
    }
}