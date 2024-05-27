using MongoDB.Model;

namespace MongoDB.Repository.Interface
{
    internal interface IBookRepository
    {
        public void CreateBook(Book book);
        public List<Book> GetAllBooks();
        public Book GetBookById(string id);
        public Book GetFirstBookByName(string name);
        public void UpdateBook(string id, Book bookIn);
        public void DeleteBook(string id);
        public void DeleteAllBooks();
    }
}
