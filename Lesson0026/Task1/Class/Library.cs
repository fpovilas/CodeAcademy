namespace Task1.Class
{
    internal class Library
    {
        private List<string> Books {  get; set; } = new();
        private List<Book> ListOfBooks { get; set; } = new();

        public void AddBook(string book)
        { Books.Add(book); }

        public void AddBook(Book book)
        { ListOfBooks.Add(book); }

        public void RemoveBook(string book)
        {  Books.Remove(book); }

        public void RemoveBook(Book book)
        { ListOfBooks.Remove(book); }

        public void PrintBooks()
        {
            foreach (string book in Books)
            {
                Console.WriteLine(book);
            }
        }

        public void PrintBooks(string type)
        {
            foreach (Book book in ListOfBooks)
            {
                if(type == "Book")
                    Console.WriteLine(book.GetTitle());
            }
        }
    }
}
