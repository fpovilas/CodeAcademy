namespace Task2.Class
{
    internal class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int ReleaseYear { get; set; }
        public string CountryCode { get; set; }

        public Book(string title, string author, int releaseYear)
        {
            Title = title;
            Author = author;
            ReleaseYear = releaseYear;
        }

        public Book(string title, string author, int releaseYear, string countryCode)
                    : this(title, author, releaseYear)
        {
            CountryCode = countryCode;
        }
    }
}
