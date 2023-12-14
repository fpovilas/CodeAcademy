namespace Task1.Class
{
    internal class Book
    {
        private string Title { get; set; }
        private string Author { get; set; }
        private int Pages { get; set; }

        public Book(string title)
        {
            Title = title;
        }

        public Book(string title, string author, int pages) : this(title)
        {
            Author = author;
            Pages = pages;
        }

        public string GetTitle() => Title;

        public string GetAuthor() => Author;

        public int GetPages() => Pages;

        public double GetReadTime()
        {
            return (double)Pages / 50;
        }


    }
}
