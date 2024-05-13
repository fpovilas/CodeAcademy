using Notepad.Repository.Database;
using Notepad.Repository.Repository.Interface;

namespace Notepad.Repository.Repository
{
    public class NoteRepository(NotepadDbContext context) : INoteRepository
    {
    }
}