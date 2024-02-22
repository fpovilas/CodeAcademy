using MongoDB.Model;

namespace MongoDB.Repository.Interface
{
    internal interface IPageRepository
    {
        public void CreatePage(Page page);
        public List<Page> GetAllPages();
        public Page GetPageByID(string id);
        public void UpdatePage(string id, Page pageIn);
        public void DeletePage(string id);
        public void DeleteAllPages();
    }
}
