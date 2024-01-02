using Task4.Class;

namespace Task4
{
    internal class Program
    {
        static void Main()
        {
            Team zalgirisBasket = new();
            zalgirisBasket.SetTeamName("Žalgiris");
            zalgirisBasket.SetSportsName("Basketball");

            Team lietkabelisBasket = new();
            lietkabelisBasket.SetTeamName("Lietkabelis");
            lietkabelisBasket.SetSportsName("Basketball");

            Team siauliaiBasket = new();
            siauliaiBasket.SetTeamName("Šiaulių Šiauliai");
            siauliaiBasket.SetSportsName("Basketball");

            Team zalgirisSoccer = new();
            zalgirisSoccer.SetTeamName("Žalgiris");
            zalgirisSoccer.SetSportsName("Soccer");

            League<Team> league = new();
            league.AddSportLeague(zalgirisBasket);
            league.AddSportLeague(lietkabelisBasket);
            league.AddSportLeague(siauliaiBasket);
            league.AddSportLeague(zalgirisSoccer);
        }
    }
}
/*
 * Create a generic class for sports game leagues.
 * The class must allow you to add a new team to the list of its league.
 * The class must have a method to print all the commands.
 * The class must only allow teams from the same sport to be added, if a team from a different sport is added, the program must discard error.
*/