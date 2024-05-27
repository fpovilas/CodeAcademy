namespace Notepad.Shared.Dto
{
    public record UserDto
    {
        public required string Username { get; set; }
        public required string Role { get; set; }
        public required List<GetNoteDto> Notes { get; set; }
    }
}