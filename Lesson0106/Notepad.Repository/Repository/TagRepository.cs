using Notepad.Repository.Database;
using Notepad.Repository.Model;
using Notepad.Repository.Repository.Interface;

namespace Notepad.Repository.Repository
{
    public class TagRepository(NotepadDbContext context) : ITagRepository
    {
        public void Create(string tagName)
        {
            Tag tag = new()
            {
                Name = tagName
            };

            context.Tags.Add(tag);
            context.SaveChanges();
        }

        public bool Edit(int id, string newTagName)
        {
            Tag? tag = context.Tags.FirstOrDefault(t => t.Id == id);
            if (tag == null)
            { return false; }

            tag.Name = newTagName;
            context.SaveChanges();
            return true;
        }

        public void Delete(int id)
        {
            var tag = context.Tags.FirstOrDefault(t => id == t.Id);

            if (tag is not null)
            {
                context.Tags.Remove(tag);
                context.SaveChanges();
            }
            else
            {
                throw new Exception();
            }
        }

        public Tag? Get(int id)
            => context.Tags.FirstOrDefault(t => t.Id.Equals(id));

        public Tag? GetByName(string tagName)
            => context.Tags.FirstOrDefault(t => t.Name.Equals(tagName));
    }
}