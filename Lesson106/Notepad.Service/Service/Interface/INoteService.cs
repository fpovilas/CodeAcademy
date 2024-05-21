using Notepad.Shared.Dto;

namespace Notepad.Service.Service.Interface
{
    public interface INoteService
    {
        public bool Create(NoteDto note);
    }
}