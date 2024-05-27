using ManyToMany.Model;

namespace ManyToMany.Repository.Interface
{
    internal interface ITagRepository
    {
        public Tag GetTag(string tagName);
    }
}
