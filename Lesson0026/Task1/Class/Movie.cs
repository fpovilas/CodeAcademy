namespace Task1.Class
{
    internal class Movie
    {
        private string Title { get; set; }
        private string Genre { get; set; }
        private int Rating { get; set; }

        public Movie(string  title, string genre, int rating)
        {
            Title = title;
            Genre = genre;
            Rating = rating;
        }

        public string GetTitle()
        {
            return Title;
        }

        public string GetGenre()
        {
            return Genre;
        }

        public int GetRating()
        {
            return Rating;
        }
    }
}
