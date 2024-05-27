namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PrintMenu();

            string choice = GetChoice();

            switch (choice)
            {
                case "2.1":
                    Dictionary<string, int> cityAndPopulation = new Dictionary<string, int>()
                    {
                        {"Šiauliai", 100653},
                        {"Klaipėda", 152008},
                        {"Telšiai", 22642},
                        {"Biržai", 10734}
                    };

                    PrintDictionaryOnlyCities(cityAndPopulation);

                    Console.Write("Please enter a city: ");
                    string cityChoice = Console.ReadLine();

                    PrintDictionaryCityAndPopulation(cityAndPopulation, cityChoice);
                    break;
                case "2.2":
                    Dictionary<string, string> wordAndTranslation = new Dictionary<string, string>()
                    {
                        {"Hello", "Labas"},
                        {"Thank you", "Ačiū"},
                        {"Bye", "Viso"},
                        {"Elephant", "Dramblys"}
                    };

                    PrintDictionaryOnlyWords(wordAndTranslation);

                    Console.Write("Please enter a word to translate: ");
                    string wordToTranslate = Console.ReadLine();

                    PrintDictionaryTranslatedWord(wordAndTranslation, wordToTranslate);
                    break;
                case "2.3":
                    Dictionary<string, List<int>> nameAndGrades = new Dictionary<string, List<int>>()
                    {
                        {"Povilas", new List<int>{10, 5, 6} },
                        {"Ieva", new List<int>{10, 9, 8, 10} },
                        {"Lukas", new List<int>{10, 5, 2} },
                        {"Petras", new List<int>{10, 5, 10, 7} }
                    };

                    PrintDictionaryNames(nameAndGrades);

                    Console.Write("Please enter stundets name: ");
                    string chosenStudent = Console.ReadLine();

                    PrintDictionaryNameAndGrades(nameAndGrades, chosenStudent);
                    break;
                case "2.4":
                    Dictionary<string, int> monthAndDayCount = new Dictionary<string, int>()
                    {
                        {"January", 31},
                        {"February", 29},
                        {"March", 31},
                        {"April", 30},
                        {"May", 31},
                        {"June", 30},
                        {"July", 31},
                        {"August", 31},
                        {"September", 30},
                        {"October", 31},
                        {"November", 30},
                        {"December", 31}
                    };

                    PrintMonthsThatDayCountIsLessThan31(monthAndDayCount);
                    break;
                default:
                    Console.WriteLine("Wrong choice...");
                    break;
            }
        }

        private static void PrintMenu()
        {
            Console.WriteLine("""
            2.1 Dictionary that stores City name as Key and Population as Value.
            2.2 Dictionary that stores English word as Key and Translation to Lithuanian as Value. Prints translation when entered in english.
            2.3 Dictionary that stores Student name as Key and Grades as Value. Displays grades when name is entered
            2.4 Dictionary that stores Months name as Key and Day number as Value. Displays moths that has less tha 31 days
            """);
        }

        private static string GetChoice()
        {
            Console.Write("Please enter your choice: ");
            return Console.ReadLine();
        }

        private static void PrintDictionaryOnlyCities(Dictionary<string, int> cityAndPopulation)
        {
            foreach(KeyValuePair<string, int> pair in cityAndPopulation)
            {
                Console.WriteLine(pair.Key);
            }
        }

        private static void PrintDictionaryCityAndPopulation(Dictionary<string, int> cityAndPopulation, string city)
        {
                Console.WriteLine($"In {city} city lives {cityAndPopulation[city]} people");
        }

        private static void PrintDictionaryOnlyWords(Dictionary<string, string> wordAndTranslation)
        {
            foreach(var pair in wordAndTranslation)
                Console.WriteLine(pair.Key);
        }

        private static void PrintDictionaryTranslatedWord(Dictionary<string, string> wordAndTranslation, string word)
        {
                Console.WriteLine($"{word} in lithuanian means {wordAndTranslation[word]}");
        }

        private static void PrintDictionaryNames(Dictionary<string, List<int>> nameAndGrades)
        {
            foreach (var pair in nameAndGrades)
            {
                Console.WriteLine(pair.Key);
            }
        }

        private static void PrintDictionaryNameAndGrades(Dictionary<string, List<int>> nameAndGrades, string name)
        {
            Console.Write($"{name}'s grades is ");
            for(int i = 0; i < nameAndGrades[name].Count; i++)
            {
                if (i < nameAndGrades[name].Count - 1)
                {
                    Console.Write($"{nameAndGrades[name][i]}, ");
                }
                else { Console.Write($"{nameAndGrades[name][i]}.\n"); }
            }
        }

        private static void PrintMonthsThatDayCountIsLessThan31(Dictionary<string, int> dictionary)
        {
            foreach(var pair in dictionary)
            {
                if(pair.Value < 31)
                    Console.WriteLine(pair.Key + " " + pair.Value);
            }
        }
    }
}