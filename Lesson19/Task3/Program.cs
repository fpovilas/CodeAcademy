namespace Task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PrintMenu();

            string choice = GetChoice();

            switch (choice)
            {
                case "3.1":
                    Dictionary<string, int> wordAndWordCount = new Dictionary<string, int>();
                    bool loop = true;

                    do
                    {
                        Console.Write("Please enter a word (to stop enter -1): ");
                        string word = Console.ReadLine();
                        if (word == "-1")
                            loop = false;
                        else
                        {
                            if (wordAndWordCount.ContainsKey(word))
                                wordAndWordCount[word]++;
                            else { wordAndWordCount.Add(word, 1); }
                        }
                    }
                    while (loop);

                    PrintDictionaryWordAndCount(wordAndWordCount);
                    break;
                case "3.2":
                    Dictionary<string, List<string>> movieTitleAndGenre = new Dictionary<string, List<string>>()
                    {
                        {"Title #1", new List<string>{"Horror", "Detective"} },
                        {"Title #2", new List<string>{"Detective"} },
                        {"Title #3", new List<string>{"Horror"} },
                        {"Title #4", new List<string>{"Romance", "Detective", "Sci-Fi"} },
                        {"Title #5", new List<string>{"Sci-Fi"} }
                    };

                    List<string> listOfGenre = CreateAListOfGenre(movieTitleAndGenre);

                    PrintList(listOfGenre);

                    Console.Write("Please enter a genre: ");
                    string chosenGenre = Console.ReadLine();

                    PrintDictionaryTitles(movieTitleAndGenre, chosenGenre);
                    
                    break;
                case "3.3":
                    
                    break;
                default:
                    Console.WriteLine("Wrong choice...");
                    break;
            }
        }

        private static void PrintMenu()
        {
            Console.WriteLine("""
            3.1 Lets user enter words and check how much time it has appeared
            3.2 Dictionary with movie Titles and Genres. Allows to select a Genre and prints titles
            3.3 
            """);
        }

        private static string GetChoice()
        {
            Console.Write("Please enter your choice: ");
            return Console.ReadLine();
        }

        private static void PrintDictionaryWordAndCount(Dictionary <string, int> wordAndWordCount)
        {
            foreach(var word in wordAndWordCount)
            {
                Console.WriteLine($"{word.Key} was written {word.Value} times");
            }
        }

        private static List<string> CreateAListOfGenre(Dictionary<string, List<string>> genre)
        {
            List<string> list = new List<string>();
            
            foreach(KeyValuePair<string, List<string>> pair in genre)
            {
                foreach (var item in pair.Value)
                {
                    if (!list.Contains(item))
                    {
                        list.Add(item);
                    }
                }
            }

            return list;
        }

        private static void PrintList(List<string> list)
        {
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }

        private static void PrintDictionaryTitles(Dictionary<string, List<string>> movieTitleAndGenre, string chosenGenre)
        {
            foreach(KeyValuePair<string, List<string>> pair in movieTitleAndGenre)
            {
                if (pair.Value.Contains(chosenGenre))
                    Console.WriteLine(pair.Key);
            }
        }
    }
}