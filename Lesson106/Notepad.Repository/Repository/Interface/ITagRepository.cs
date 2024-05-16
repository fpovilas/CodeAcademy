using Notepad.Repository.Model;

namespace Notepad.Repository.Repository.Interface
{
    public interface ITagRepository
    {
        public void Create(string tagName);
        public void Delete(int id);
        public bool Edit(int id, string newTagName);
        public Tag? Get(int id);
    }
}
