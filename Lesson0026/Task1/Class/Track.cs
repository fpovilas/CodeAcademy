namespace Task1.Class
{
    internal class Track
    {
        private string Title { get; set; }

        public Track (string title) { Title = title; }

        public string GetTitle() { return Title; }
    }
}
