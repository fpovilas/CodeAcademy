using MongoDB.Driver;
using MongoDB.Model;
using MongoDB.Repository.Interface;

namespace MongoDB.Repository
{
    internal class PageRepository : IPageRepository
    {
        private readonly IMongoCollection<Page> _pages;
        public PageRepository()
        {
            const string connectionUri = "mongodb+srv://fpovilas:9XTqdAmQfHxmf@mongodb.vpiwb1q.mongodb.net/?retryWrites=true&w=majority&appName=MongoDB";

            var settings = MongoClientSettings.FromConnectionString(connectionUri);
            settings.ServerApi = new ServerApi(ServerApiVersion.V1);

            var client = new MongoClient(settings);

            var database = client.GetDatabase("Library");
            _pages = database.GetCollection<Page>("pages");
        }
        public void CreatePage(Page page)
        {
            _pages.InsertOne(page);
        }
        public List<Page> GetAllPages()
        {
            return _pages.Find(page => true).ToList();
        }
        public Page GetPageByID(string id)
        {
            return _pages.Find<Page>(page => page.ID == id).FirstOrDefault();
        }
        public void UpdatePage(string id, Page pageIn)
        {
            _pages.ReplaceOne(page => page.ID == id, pageIn);
        }
        public void DeletePage(string id)
        {
            _pages.DeleteOne(page => page.ID == id);
        }
        public void DeleteAllPages()
        {
            _pages.DeleteMany(page => true);
        }
    }
}
