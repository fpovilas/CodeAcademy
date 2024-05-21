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
    }
}