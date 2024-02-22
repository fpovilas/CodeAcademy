using MongoDB.Driver;
using MongoDB.Model;
using MongoDB.Repository.Interface;

namespace MongoDB.Repository
{
    internal class BookRepository : IBookRepository
    {
        private readonly IMongoCollection<Book> _books;
        public BookRepository()
        {
            const string connectionUri = "mongodb+srv://username:password@mongodb.vpiwb1q.mongodb.net/?retryWrites=true&w=majority&appName=MongoDB";

            var settings = MongoClientSettings.FromConnectionString(connectionUri);
            settings.ServerApi = new ServerApi(ServerApiVersion.V1);

            var client = new MongoClient(settings);

            var database = client.GetDatabase("Library");
            _books = database.GetCollection<Book>("books");
        }
        public void CreateBook(Book book)
        {
            _books.InsertOne(book);
        }
        public List<Book> GetAllBooks()
        {
            return _books.Find(book => true).ToList();
        }
        public Book GetBookById(string id)
        {
            return _books.Find<Book>(book => book.ID == id).FirstOrDefault();
        }
        public Book GetFirstBookByName(string name)
            => _books.Find<Book>(book => book.Name == name).FirstOrDefault();
        public void UpdateBook(string id, Book bookIn)
        {
            _books.ReplaceOne(book => book.ID == id, bookIn);
        }
        public void DeleteBook(string id)
        {
            _books.DeleteOne(book => book.ID == id);
        }
        public void DeleteAllBooks()
        {
            _books.DeleteMany(book => true);
        }

    }
}
