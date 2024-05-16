using Notepad.Repository.Model;

namespace Notepad.Service.Service.Interface
{
    public interface ITagService
    {
        public bool Create(string tagName);
        public bool Delete(int id);
        public bool Edit(int id, string newTagName);
        public bool Get(int id, out Tag tag);
    }
}
