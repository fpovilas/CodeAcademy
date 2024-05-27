using ManyToMany.DB;
using ManyToMany.Model;
using ManyToMany.Repository.Interface;

namespace ManyToMany.Repository
{
    internal class TagRepository(FileContext context) : ITagRepository
    {
        private readonly FileContext _context = context;

        public Tag GetTag(string tagName) => _context.Tags.FirstOrDefault(t => t.TagName == tagName) ?? new();
    }
}
