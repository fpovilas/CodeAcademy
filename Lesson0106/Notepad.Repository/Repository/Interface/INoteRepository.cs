using Notepad.Repository.Model;

namespace Notepad.Repository.Repository.Interface
{
    public interface INoteRepository
    {
        public void Create(Note note);
        public List<Note> GetAll(int id);
        public void Remove(Note note);
        public void Update(Note note);
    }
}