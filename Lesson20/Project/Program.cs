namespace Project
{
    internal class Program
    {
        static void Main()
        {
            #region Variables

            Dictionary<string, Dictionary<int, int>> playerAndScore = new()
            {
                { "Povilas Frišmantas", new Dictionary < int, int >(){ { 1, 0 }, { 2, 0 } } }
            };
            bool stopGame = false;
            bool isLoggedIn = false;
            string firstName;
            string currentUser = string.Empty;

            #endregion

            Console.Title = "Mind games. Over 9K";

            do
            {
                // Prints two different menus
                PrintMenu(isLoggedIn, currentUser);

                int choice = GetChoice();

                switch (choice)
                {
                    // Log in/Play game
                    case 1:

                        if (!isLoggedIn)
                        {
                            firstName = GetUserNameAndLastName(out string lastName);
                            // Checks if player with provided Log in cred exists.
                            // If not ask if player wants to create it
                            CreateUserKey(ref currentUser, firstName, lastName);
                            if (!playerAndScore.ContainsKey(currentUser))
                            {
                                bool createPlayer = PrintPlayerDoesNotExist();

                                if (createPlayer)
                                {
                                    PrintCreatedPlayer(playerAndScore, firstName, lastName);
                                }
                            }
                            else
                            {
                                isLoggedIn = true;
                                PrintWarning(currentUser);
                            }
                        }
                        else
                        {
                            PrintCategories();
                            int category = GetChoice();
                            PlayGame(playerAndScore, currentUser, category);
                        }

                        break;
                    // Print rules
                    case 2:
                        PrintGameRules();
                        break;
                    // Exit game/View stats
                    case 3:
                        if (isLoggedIn)
                        {
                            PrintMenuForStats();

                            int statChoice = GetChoice();

                            switch (statChoice)
                            {
                                case 1:
                                    PrintParticipants(playerAndScore);
                                    break;
                                case 2:
                                    PrintScoreBoard(playerAndScore);
                                    break;
                                default:
                                    break;
                            }
                        }
                        else { stopGame = true; }
                        break;
                    // Log out
                    case 4:
                        if (isLoggedIn)
                        {
                            isLoggedIn = false;
                            PrintLoggedOutMessage(currentUser);
                        }
                        break;
                    // Exit when logged in
                    case 5:
                        if (isLoggedIn) { stopGame = true; }
                        break;
                    default:
                        Console.WriteLine("\nWrong choice please try again.\n");
                        break;
                }
            } while (!stopGame);
        }

        #region Print Functions

        private static void PrintMenu(bool isLoggedIn, string currentUser)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;

            if (!isLoggedIn)
            {
                Console.Clear();
                Console.WriteLine("""
                1. Log In
                2. Game rules
                3. Exit Game
                """);
            }
            else
            {
                Console.Clear();
                PrintSentenceYouAreLoggedInAs(currentUser);
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("""
                    1. Play Game
                    2. Game rules
                    3. View Statistics
                    4. Log Out
                    5. Exit Game
                    """);
            }
            Console.ResetColor();
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

            return answer.ToLower() == "y";
        }

        private static void PrintCreatedPlayer(Dictionary<string, Dictionary<int,int>> player, string firstName, string lastName)
        {
            Console.ForegroundColor= ConsoleColor.DarkMagenta;

            Console.WriteLine("\nCreating player...");
            CreateUser(player, firstName, lastName);
            Console.Write("Player ");

            Console.ForegroundColor = ConsoleColor.DarkGreen;

            Console.Write($"{firstName} {lastName}");

            Console.ForegroundColor = ConsoleColor.DarkMagenta;

            Console.WriteLine(" created...\n");

            Console.ResetColor();

            Console.ReadKey(true);
        }

        private static void PrintGameRules()
        {
            Console.Clear ();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("        Mind games. Over 9K - Game Rules");
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("""

                During game you face 20 questions to which you'll
                have 4 possible answers. From thouse 4 answers
                only one is correct. Every answer wroth 1 point.
                At the end of game you will be presented with
                your statistics how you managed to play the game.

                                   Good luck.

                """);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("To exit rules press eny key...");
            Console.ReadKey(true);
            Console.ResetColor();
        }

        private static void PrintWarning(string userKey)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("You have logged in into ");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write(userKey);
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(" account!");
            Console.ResetColor();
            Console.WriteLine("Please press enter to continue...");
            Console.ReadKey(true);
        }

        private static void PrintPossibleAnswers(Dictionary<int, List<string>> possibleAnswers, int questionToPrint)
        {
            Console.WriteLine();
            for (int i = 0; i < possibleAnswers[questionToPrint].Count; i++)
            {
                Console.WriteLine($"{i + 1,3}. {possibleAnswers[questionToPrint][i],-35}");
            }
        }

        private static void PrintSentenceYouAreLoggedInAs(string currentUser)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("You are logged in as ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"{currentUser}");
            Console.WriteLine();
        }

        private static void PrintLoggedOutMessage(string currentUser)
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("You are logged out from ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"{currentUser}");

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\nPress any key to continue");

            Console.ReadKey(true);
        }

        private static void PrintMenuForStats()
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("""
                1. See all participants
                2. See score board
                """);

            Console.ResetColor();
        }

        private static void PrintParticipants(Dictionary<string, Dictionary<int, int>> players)
        {
            Console.Clear();

            foreach(KeyValuePair<string, Dictionary<int, int>> player in players)
            {
                Console.WriteLine($"{player.Key}");
            }

            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("\nPress any key to continue...");
            Console.ResetColor();
            Console.ReadKey(true);
        }

        private static void PrintScoreBoard(Dictionary<string, Dictionary<int, int>> players)
        {
            Dictionary<int, string> questionThemes = new() // Question themes
            {
                { 1, "General Knowlagde Questions" },
                { 2, "Films" }
            };
            Dictionary<string, Dictionary<int, int>> workablePlayers = players;

            Dictionary<string, int> playerAndSummedScore = CreateSummedScoreDictionary(workablePlayers);

            playerAndSummedScore = playerAndSummedScore.OrderByDescending(x => x.Value).ToDictionary(x  => x.Key, x => x.Value);

            Console.Clear();

            int counter = 1;

            foreach(var player in playerAndSummedScore)
            {
                if (counter <= 10)
                {
                    if (counter <= 3)
                    {
                        Console.Write($"{player.Key} ");
                        AddStar(counter);
                        Console.WriteLine();
                        PrintPlayerScore(workablePlayers[player.Key], questionThemes);
                    }
                    else
                    {
                        PrintPlayerScore(workablePlayers[player.Key], questionThemes);
                    }
                }
                else { return; }
                counter++;
            }

            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("\nPress any key to continue...");
            Console.ResetColor();
            Console.ReadKey(true);
        }

        private static void PrintEndGameScore(int correctAnswers, int questionCount)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"Score: {correctAnswers}/{questionCount}");
            Console.ResetColor();
            Console.ReadKey(true);
        }

        private static void PrintCategories()
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("""
                1. General Knowlage Questions
                2. Films
                """);
            Console.ResetColor();
        }

        private static void PrintPlayerScore(Dictionary<int, int> playerScore, Dictionary<int, string> questionThemes)
        {
            int theme = 1;
            foreach (var score in playerScore)
            {
                double percentage = (double)score.Value / 20 * 100;
                Console.WriteLine($"\t{score.Value}/20 {(percentage == 0 ? "0" : percentage):#.##}% -- {questionThemes[theme]}");
                theme++;
            }
        }

        #endregion

        #region Get Functions

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

        private static string GetUserNameAndLastName(out string lastName)
        {
            Console.Clear();

            string firstName;

            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("Please enter your first name: ");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            firstName = Console.ReadLine() ?? string.Empty;

            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("Please enter your last name: ");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            lastName = Console.ReadLine() ?? string.Empty;

            Console.ResetColor();

            return firstName;
        }

        private static int GetRandomNumber(int maxVal)
        {
            Random rnd = new ();
            int minVal = 1;
            int value = rnd.Next(minVal, maxVal + 1);
            return value;
        }

        private static int GetRandomQuestionNumber(List<int> alreadyUsedQuestions, int maxValue)
        {
            int val;

            do
            {
                val = GetRandomNumber(maxValue);
            }
            while (alreadyUsedQuestions.Contains(val));

            alreadyUsedQuestions.Add(val);
            return val;
        }

        #endregion

        #region Create Functions

        private static void CreateUserKey(ref string userKey, string firstName, string lastName)
        {
            userKey = string.Join(" ", new string[] { firstName, lastName });
        }

        private static void CreateUser(Dictionary<string, Dictionary<int, int>> player, string firstName, string lastName)
        {
            player.Add($"{firstName} {lastName}", new Dictionary<int, int> { { 1, 0 }, { 2, 0 } });
        }

        private static Dictionary<string, int> CreateSummedScoreDictionary(Dictionary<string, Dictionary<int, int>> workablePlayers)
        {
            Dictionary<string, int> playerAndSummedScore = new Dictionary<string, int>();
            int sum = 0;

            foreach (var player in workablePlayers)
            {
                foreach (var score in player.Value)
                {
                    sum += score.Value;
                }
                playerAndSummedScore.Add(player.Key, sum);
            }

            return playerAndSummedScore;
        }

        #endregion

        private static void AddStar(int counter)
        {
            for(int i = 0; i < counter; i++)
            {
                Console.Write('*');
            }
        }

        private static void PrepareForGame(out Dictionary<int, string> questions, out Dictionary<int, List<string>> possibleAnswers, out Dictionary<int, string> answers, int category)
        {
            Dictionary<int, string> questionsGeneral = new ()
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
            Dictionary<int, List<string>> possibleAnswersGeneral = new ()
            {
                {1, new List<string> {"1912", "2012", "1946", "2023"} },
                {2, new List<string> {"Mask", "Carry on Sergeant", "21st Jump street", "Vimpire" } },
                {3, new List<string> {"Nokia", "Xiaomi", "Sony Ericsson", "Samsung" } },
                {4, new List<string> { "Dave Bartram", "Ray Charles", "Frank Sinatra", "Elvis Presley" } },
                {5, new List<string> { "Jamie Oliver", "Gordon Ramsay", "Joshua Weissman", "Susur Lee" } },
                {6, new List<string> { "Jack Black", "Michael Brendon", "Christian Kist", "Josh Maximus" } },
                {7, new List<string> { "Gold", "Aluminium", "Iron", "Silver" } },
                {8, new List<string> { "Lisbon", "Vilnius", "Berlin", "Seoul" } },
                {9, new List<string> { "5,000 daily", "50,000 daily", "18,000 daily", "20,000 daily" } },
                {10, new List<string> { "Lord John Russell", "Robert Peel", "Robert Walpole", "Theresa May" } },
                {11, new List<string> { "Ag", "Fe", "Au", "Hg" } },
                {12, new List<string> { "Percy Shaw", "Thomas Savery", "Isaac Newton", "Bryan Donkin" } },
                {13, new List < string > { "Carolina Wren", "Bee Hummingbird", "Blue Parot", "Bushtit" }},
                {14, new List < string > { "Lewis Collins and Martin Shaw", "Adam Sandler and Jackie Sandler", "Macaulay Culkin and Brenda Song", "Warren Beatty and Faye Dunaway" }},
                {15, new List < string > { "Barbie", "Estelle Parsons", "Barbara Millicent Roberts", "Sadie French" }},
                {16, new List < string > { "The loudest burp", "The loudest fart", "The loudest scream", "The loudest voice" }},
                {17, new List < string > { "Drug dealer", "A used furniture salesman", "Chemist", "Mechanic" }},
                {18, new List < string > { "8 hours", "3 days", "1 month", "24 hours" }},
                {19, new List < string > { "1947", "1945", "1960", "1949" }},
                {20, new List < string > { "James Winchester", "Peter Durand", "Jack Solomon", "Bob McLeslie" }}
            };
            Dictionary<int, string> answersGeneral = new ()
            {
                { 1, "1912" },
                { 2, "Carry on Sergeant" },
                { 3, "Samsung" },
                { 4, "Dave Bartram" },
                { 5, "Jamie Oliver" },
                { 6, "Christian Kist" },
                { 7, "Aluminium" },
                { 8, "Lisbon" },
                { 9, "20,000 daily" },
                { 10, "Robert Peel" },
                { 11, "Ag" },
                { 12, "Percy Shaw" },
                { 13, "Bee Hummingbird" },
                { 14, "Lewis Collins and Martin Shaw" },
                { 15, "Barbara Millicent Roberts" },
                { 16, "The loudest burp" },
                { 17, "A used furniture salesman" },
                { 18, "24 hours" },
                { 19, "1947" },
                { 20, "Peter Durand" }
            };

            Dictionary<int, string> questionsFilm = new ()
            {
                { 1, "In which year was The Godfather first released?" },
                { 2, "Which actor won the best actor Oscar for the films Philadelphia (1993) and Forrest Gump (1994)?" },
                { 3, "How many self-referential cameos did Alfred Hitchcock make in his films from 1927-1976?" },
                { 4, "Which 1982 film was greatly accepted by film fans for its portrayal of the love between a young, fatherless suburban boy and a lost, benevolent and homesick visitor from another planet?" },
                { 5, "Which actress played Mary Poppins in the 1964 film Mary Poppins?" },
                { 6, "In which 1963 classic film did Charles Bronson appear?" },
                { 7, "In which 1995 film did Sandra Bullock play the character Angela Bennett – Wrestling Ernest Hemingway?" },
                { 8, "Which New Zealand female director directed these films – In the Cut (2003), The Water Diary (2006) and Bright Star (2009)?" },
                { 9, "Which actor provided the voice for the character Nemo in the 2003 film Finding Nemo?" },
                { 10, "Which prisoner dubbed ‘the most violent prisoner in Britain’ was the subject of a 2009 film?"},
                { 11, "What 2008 film starring Chritian Bale has this quote: “I believe whatever doesn’t kill you, simply makes you…stranger,”?"},
                { 12, "American actress who played the part of Tokyo underworld boss O-Ren Ishii in KillBill Vol I & II"},
                { 13, "In which film did Hugh Jackman star as a rival magician of the character played by Christian Bale?"},
                { 14, "The film director, Frank Capra, famous for It’s a Wonderful Life, was born in which mediteranean country?"},
                { 15, "Which British action actor played the part of Lee Christmas alongside Sylvester Stallone in the film The Expendables?"},
                { 16, "Which American actor starred alongside Kim Bassinger in the film 9½ Weeks?"},
                { 17, "Which former Doctor Who actress played the part of Nebula in ‘Avengers:Infinity War’?"},
                { 18, "Who starred as Juno MacGuff opposite Michael Cera in the 2007 film Juno?"},
                { 19, "What is the name of the 2015 film about a frontiersman on a fur trading expedition in the 1820s and his fight for survival after being mauled by a bear?"},
                { 20, "Which film starring Chris Hemsworth and Daniel Brühl, charts the Formula 1 rivalry of James Hunt and Niki Lauda?"}
        };
            Dictionary<int, List<string>> possibleAnswersFilm = new ()
            {
                { 1, new List<string> {"1972", "1965", "1975", "1983"} },
                { 2, new List < string > { "Johnny Depp", "Jason Stathma", "Tom Hanks", "Triple H" }},
                { 3, new List < string > { "50", "33", "37", "35" }},
                { 4, new List < string > { "E.T.", "E.T. The Extra-Terra", "E.T. The Extra-Terrestrial", "The Exta-T-Section" }},
                { 5, new List < string > { "Jenny Jeninks", "Penelope Cruz", "Bonnie Tyler", "Julie Andrews" }},
                { 6, new List < string > { "The Great Mountain", "The Great Lake", "The Great Escape", "The Great Swamp" }},
                { 7, new List < string > { "The Net", "Salt", "28 Days", "Leo" }},
                { 8, new List < string > { "Niki Caro", "Renae Maihi", "Jess Johnson", "Jane Campion" }},
                { 9, new List < string > { "Albert Brooks", "Stephen Root", "Alexander Gould", "Willem Dafoe" }},
                { 10, new List < string > { "Joanna Dennehy", "Charles Bronson", "Damien Fowkes", "Robert Maudsley" }},
                { 11, new List < string > { "The Pale Blue Eye", "The Dark Knight", "Hostiles", "Batman Begins" }},
                { 12, new List < string > { "Lucy Liu", "Zoey Deutch", "Amanda Bynes", "E. G. Daily" }},
                { 13, new List < string > { "The Prestige", "Chappie", "The Front Runner", "Wolverine" }},
                { 14, new List < string > { "Italy", "France", "Portugal", "Spain" }},
                { 15, new List < string > { "Cillian Murphy", "Ian McKellen", "Patrick Stewart", "Jason Statham" }},
                { 16, new List < string > { "Ned Dennehy", "Mickey Rourke", "Finn Cole", "Ian Peck" }},
                { 17, new List < string > { "Helen McCrory", "Scarlett Johansson", "Karen Gillan", "Zoe Saldana" }},
                { 18, new List < string > { "Ellen Page/Elliot Page", "Mary-Kate/Ashley Olsen", "Nikki Bella/Brie Bella", "Diedre Hall/Andrea Hall" }},
                { 19, new List < string > { "Path of the Panther", "The Revenant", "Kid 90", "The Right Stuff" }},
                { 20, new List < string > { "Rush", "Grand Prix", "Senna", "Weekend of a Champion" }}
            };
            Dictionary<int, string> answersFilm = new ()
            {
                { 1, "1972"},
                { 2, "Tom Hanks"},
                { 3, "37"},
                { 4, "E.T. The Extra-Terrestrial"},
                { 5, "Julie Andrews"},
                { 6, "The Great Escape"},
                { 7, "The Net"},
                { 8, "Jane Campion"},
                { 9, "Alexander Gould"},
                { 10, "Charles Bronson (the film was titled Bronson)"},
                { 11, "The Dark Knight"},
                { 12, "Lucy Liu"},
                { 13, "The Prestige"},
                { 14, "Italy"},
                { 15, "Jason Statham"},
                { 16, "Mickey Rourke"},
                { 17, "Karen Gillan"},
                { 18, "Ellen Page/Elliot Page"},
                { 19, "The Revenant"},
                { 20, "Rush"}
            };

            Dictionary<int, Dictionary<int, string>> categorisedQuestions = new()
            {
                    {1, questionsGeneral },
                    {2, questionsFilm }
            };
            Dictionary<int, Dictionary<int, List<string>>> categorisedPossibleAnswers = new()
            {
                { 1, possibleAnswersGeneral },
                { 2, possibleAnswersFilm },
            };
            Dictionary<int, Dictionary<int, string>> categorisedAnswers = new()
            {
                { 1, answersGeneral },
                { 2, answersFilm }
            };

            questions = categorisedQuestions[category];
            possibleAnswers = categorisedPossibleAnswers[category];
            answers = categorisedAnswers[category];
        }

        private static void PlayGame(Dictionary<string, Dictionary<int, int>> player, string userKey, int category)
        {
            bool stopGame = false;

            PrepareForGame(out Dictionary<int, string> questions,
                out Dictionary<int, List<string>> possibleAnswers,
                out Dictionary<int, string> answers, category);

            int questionCounter = 1;
            int howMuchQuestions = questions.Count;
            List<int> alreadyUsedQuestions = new();

            player[userKey][category] = 0;

            do
            {
                Console.Clear();

                int questionToPrint = GetRandomQuestionNumber(alreadyUsedQuestions, howMuchQuestions);

                Console.WriteLine($"{questionCounter}. {questions[questionToPrint]}");
                PrintPossibleAnswers(possibleAnswers, questionToPrint);

                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine($"\n{questionCounter}/{howMuchQuestions}");
                Console.WriteLine($"Score: {player[userKey][category]}/{questionCounter - 1}");
                Console.ResetColor();

                int answerNumber = GetChoice();
                string answer = answers[questionToPrint];
                string chosenAnswer = possibleAnswers[questionToPrint][answerNumber - 1];

                if (answer == chosenAnswer)
                {
                    player[userKey][category]++;
                }

                if (questionCounter == howMuchQuestions)
                {
                    stopGame = true;
                    PrintEndGameScore(player[userKey][category], questionCounter);
                }

                questionCounter++;
            } while (!stopGame);
        }
    }
}