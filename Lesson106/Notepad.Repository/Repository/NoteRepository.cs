using Microsoft.EntityFrameworkCore;
using Notepad.Repository.Database;
using Notepad.Repository.Model;
using Notepad.Repository.Repository.Interface;

namespace Notepad.Repository.Repository
{
    public class NoteRepository(NotepadDbContext context) : INoteRepository
    {
        public void Create(Note note)
        {
            context.Notes.Add(note);
            context.SaveChanges();
        }

        public List<Note> GetAll(int id) => context.Notes
            .Include(n => n.Tags)
            .Include(n => n.User)
            .Include(n => n.NoteImage)
            .ThenInclude(n => n!.NoteImageThumbnail)
            .ToList();

        public void Remove(Note note)
        {
            context.Remove(note);
            context.SaveChanges();
        }
    }
}