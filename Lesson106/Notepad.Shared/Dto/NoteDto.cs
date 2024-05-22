﻿namespace Notepad.Shared.Dto
{
    public class NoteDto
    {
        public required string Title { get; set; }
        public required string Description { get; set; }
        public ICollection<string>? Tags { get; set; }
        public int? UserId { get; set; }
    }
}