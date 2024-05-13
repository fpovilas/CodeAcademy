using Notepad.Repository.Repository.Interface;
using Notepad.Service.Service.Interface;

namespace Notepad.Service.Service
{
    public class NoteService(INoteRepository noteRepository) : INoteService
    {
    }
}