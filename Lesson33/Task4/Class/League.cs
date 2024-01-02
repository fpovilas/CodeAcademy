namespace Task4.Class
{
    internal class League<T>
    {
        private List<T> SportLeagues { get; set; } = new List<T>();

        public void AddSportLeague(T league)
        {
            if(SportLeagues.Count == 0)
                SportLeagues.Add(league);
            else if(SportLeagues[0]?.ToString() == league?.ToString())
            {
                SportLeagues.Add(league);  
            }
            else { ThrowError(league, SportLeagues[0]); }
        }

        private static void ThrowError<T1,T2>(T1 wrongSports, T2 correctSports)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($"{wrongSports?.ToString()} is not {correctSports?.ToString()}");
            Console.ResetColor();
        }
    }
}
