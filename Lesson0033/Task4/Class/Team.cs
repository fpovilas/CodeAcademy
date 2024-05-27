namespace Task4.Class
{
    internal class Team : Sports
    {
        private string? TeamName { get; set; }

        public string? GetTeamName() => TeamName;

        public void SetTeamName(string? teamName) => TeamName = teamName;

        public override string? ToString()
        {
            return GetSportsName();
        }
    }
}
