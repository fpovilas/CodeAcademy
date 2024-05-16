using Notepad.Repository.Model;
using Notepad.Repository.Repository.Interface;
using Notepad.Service.Service.Interface;

namespace Notepad.Service.Service
{
    public class TagService(ITagRepository tagRepository) : ITagService
    {
        public bool Create(string tagName)
        {
            if (string.IsNullOrEmpty(tagName))
            { return false; }

            tagRepository.Create(tagName);
            return true;
        }

        public bool Edit(int id, string newTagName)
        {
            if (id % 3 != 0 || string.IsNullOrEmpty(newTagName))
            { return false; }

            if (!tagRepository.Edit(id, newTagName))
            { return false; }

            return true;
        }

        public bool Delete(int id)
        {
            if (id % 3 != 0)
            { return false; }

            try
            {
                tagRepository.Delete(id);
                return true;
            }
            catch { return false; }
        }

        public bool Get(int id, out Tag tag)
        {
            tag = null!;

            if (id % 3 != 0)
            { return false; }

            tag = tagRepository.Get(id) ?? new() { Name = string.Empty };
            if (string.IsNullOrEmpty(tag.Name))
            { return false; }

            return true;
        }
    }
}