using System.Numerics;

namespace Project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Variables

            Dictionary<string, List<string>> player = new Dictionary<string, List<string>>
            {
                { "Povilas Frišmantas", new List<string> { } }
            };
            bool stopGame = false;
            bool isLoggedIn = false;
            string firstName = string.Empty;
            string lastName = string.Empty;

            #endregion

            Console.Title = "Mind games. Over 9K";

            do
            {
                // Prints two different menus
                PrintMenu(isLoggedIn);

                int choice = GetChoice();

                switch (choice)
                {
                    case 1: // Log in/Play game

                        if (!isLoggedIn)
                        {
                            GetUserNameAndLastName(ref firstName, ref lastName);
                            // Checks if player with provided Log in cred exists.
                            // If not ask if player wants to create it
                            if (!player.ContainsKey(string.Join(" ", firstName, lastName)))
                            {
                                bool createPlayer = PrintPlayerDoesNotExist();

                                if (createPlayer)
                                {
                                    PrintCreatedPlayer(player, firstName, lastName);
                                }
                            }
                            else { isLoggedIn = true; }
                        }
                        else
                        {
                            string userKey = string.Join(" ", firstName, lastName);
                            PlayGame(player, userKey);
                        }
                        break;
                    case 2:
                        if (!isLoggedIn)
                            stopGame = true;
                        break;
                    case 3:
                        if (!isLoggedIn)
                            Console.WriteLine("\nWrong choice please try again.\n");
                        else { isLoggedIn= false; }
                        break;
                    case 4:
                        if (!isLoggedIn)
                            Console.WriteLine("\nWrong choice please try again.\n");
                        else { stopGame = true; }
                        break;
                    default:
                        Console.WriteLine("\nWrong choice please try again.\n");
                        break;
                }

                //isLoggedIn = int.TryParse(Console.ReadLine(), out int choice);
            } while (!stopGame);
        }

        private static void PrintMenu(bool isLoggedIn)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;

            if (!isLoggedIn)
            {
                Console.Clear();
                Console.WriteLine("""
                1. Log In
                2. Exit Game
                """);
            }
            else
            {
                Console.Clear();
                Console.WriteLine("""
                    1. Play Game
                    2. View Statistics
                    3. Log Out
                    4. Exit Game
                    """);
            }
            Console.ResetColor();
        }

        private static int GetChoice()
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("\nPlease enter a choice: ");
            Console.ForegroundColor = ConsoleColor.Green;
            
            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                Console.WriteLine();
                Console.ResetColor();
                return choice;
            }

            Console.WriteLine();
            Console.ResetColor();
            return 0;
        }

        private static void GetUserNameAndLastName(ref string firstName, ref string lastName)
        {
            Console.Clear();

            lastName = string.Empty;
            firstName = string.Empty;

            Console.ForegroundColor= ConsoleColor.DarkMagenta;
            Console.Write("Please enter your name: ");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            firstName = Console.ReadLine() ?? string.Empty;

            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("Please enter your last name: ");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            lastName = Console.ReadLine() ?? string.Empty;

            Console.ResetColor();
        }

        private static void UserCreate(Dictionary<string, List<string>> player, string firstName, string lastName)
        {
            player.Add($"{firstName} {lastName}", new List<string> { });
        }

        private static bool PrintPlayerDoesNotExist()
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("Such player does not exist.");
            Console.Write("Do you want yo create player ");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("(y/n)");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("?: ");
            Console.ForegroundColor = ConsoleColor.DarkRed;

            string answer = Console.ReadLine() ?? string.Empty;
            Console.ResetColor();

            return answer.ToLower() == "y" ? true : false;
        }

        private static void PrintCreatedPlayer(Dictionary<string, List<string>> player, string firstName, string lastName)
        {
            Console.ForegroundColor= ConsoleColor.DarkMagenta;

            Console.WriteLine("\nCreating player...");
            UserCreate(player, firstName, lastName);
            Console.Write("Player ");

            Console.ForegroundColor = ConsoleColor.DarkGreen;

            Console.Write($"{firstName} {lastName}");

            Console.ForegroundColor = ConsoleColor.DarkMagenta;

            Console.WriteLine(" created...\n");

            Console.ResetColor();
        }

        private static void PrepareForGame(Dictionary<int, string> questions, Dictionary<int, List<string>> possibleAnswers, Dictionary<int, string> answers)
        {
            Dictionary<int, string> quests = new Dictionary<int, string>()
            {
                {1, "What year did the Titanic sink in the Atlantic Ocean on 15 April, on its maiden voyage from Southampton?"},
                {2, "What is the title of the first ever Carry On film made and released in 1958?"},
                {3, "What is the name of the biggest technology company in South Korea?"},
                {4, "Which singer fronted the 1970s pop group Showaddywaddy?"},
                {5, "Which now famous TV chef started cooking at the age of eight in his parents’ pub, ‘The Cricketers, in Clavering, Essex?"},
                {6, "Which Dutch darts player won the 2012 BDO World Championship at the Lakeside Country Club, Frimley Green on 15 January?"},
                {7, "Which metal was discovered by Hans Christian Oersted in 1825?"},
                {8, "What is the capital of Portugal?"},
                {9, "How many breaths does the human body take daily?"},
                {10, "Who was the Prime Minister of Great Britain from 1841 to 1846?"},
                {11, "What is the chemical symbol for silver?"},
                {12, "Who invented Cat’s Eyes in 1934 to improve road safety?"},
                {13, "What is the world’s smallest bird?"},
                {14, "Who played ‘Bodie’ and ‘Doyle’ in The Professionals?"},
                {15, "What is the doll, Barbie’s, full name?"},
                {16, "What does Paul Hunn hold the record for, which registered at 118.1 decibels?"},
                {17, "What did Al Capone’s business card state his occupation was?"},
                {18, "What is the lifespan of a dragonfly?"},
                {19, "Which year was the first Tonka truck made – 1945, 1947 or 1949?"},
                {20, "Who invented the tin can for preserving food in 1810?"}
        };

            foreach(KeyValuePair<int, string> quest in quests)
            {
                questions.Add(quest.Key, quest.Value);
            }
        }

        private static void PlayGame(Dictionary<string, List<string>> player, string userKey)
        {
            bool stopGame = false;
            Dictionary<int, string> questions = new Dictionary<int, string>();
            Dictionary<int, List<string>> possibleAnswers = new Dictionary<int, List<string>>();
            Dictionary<int, string> answers = new Dictionary<int, string>();

            PrepareForGame(questions, possibleAnswers, answers);

            do
            {
                Console.Clear();
            } while (!stopGame);
        }
    }
}