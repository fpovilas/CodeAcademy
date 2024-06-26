﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Notepad.Repository.Model
{
    public class Note
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }

        // Many-to-many relationship with Tag entity (Notes can have many Tags)
        public ICollection<Tag>? Tags { get; set; }

        // One-to-many relationship with User entity (User can have many Notes)
        [ForeignKey(nameof(User))]
        public int? UserId { get; set; }
        public virtual User? User { get; set; }

        // One-to-one relationship with NoteImage entity (Note can have one NoteImage)
        //[ForeignKey(nameof(NoteImage))]
        //public int? NoteImageId { get; set; }
        public virtual NoteImage? NoteImage { get; set; }
    }
}