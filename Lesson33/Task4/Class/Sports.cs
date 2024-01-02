namespace Task4.Class
{
    internal abstract class Sports
    {
        private string? SportsName { get; set; }

        public string? GetSportsName() => SportsName;

        public void SetSportsName(string? sportsName) => SportsName = sportsName;
    }
}
