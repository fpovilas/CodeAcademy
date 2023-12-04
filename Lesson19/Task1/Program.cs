using System.Runtime.InteropServices;

namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Hard Coded Vars
            int howMuchPositions = 3;

            #endregion

            PrintMenu();

            string choice = GetChoice();

            switch (choice)
            {
                case "1.1":
                    Dictionary<string, int> nameAndAgePair = CreateDictionary(howMuchPositions);

                    PrintDictionaryNameAndAge(nameAndAgePair);
                    break;
                case "1.2":
                    Dictionary<string, string> cityAndCapitalPair = new Dictionary<string, string>()
                    {
                        {"Lithuania", "Vilnius"},
                        {"Germany", "Berlin"},
                        {"France", "Paris"},
                        {"Greece", "Athene"}
                    };

                    PrintDictionaryCityAndCapital(cityAndCapitalPair);
                    Console.Write("\nPlease enter a country from the list: ");
                    string country = Console.ReadLine();

                    PrintCapital(country, cityAndCapitalPair);

                    break;
                case "1.3":
                    Dictionary<string, int> fruitAndQuantyityPair = new Dictionary<string, int>();
                    bool stopAddition = true;

                    while (stopAddition)
                    {
                        if (fruitAndQuantyityPair.Count == 0)
                        {
                            Console.WriteLine("Dictionary is empty. Please add at least one entry.");
                        }

                        Console.Write("Do you want add entry (y/n): ");
                        char answer = Convert.ToChar(Console.ReadLine());

                        if(char.ToLower(answer) != 'y')
                        {
                            stopAddition = false;
                            break;
                        }

                        AddFruitToDictionary(fruitAndQuantyityPair);
                    }

                    PrintDictionaryFruitAndQuantity(fruitAndQuantyityPair);

                    break;
                default:
                    Console.WriteLine("Wrong choice...");
                break;
            }
        }

        private static void PrintMenu()
        {
            Console.WriteLine("""
            1.1 Dictionary that stores Names as Key and Age as Value
            1.2 Dictionary that stores Country as key and Capital as Value. Prints Capital if you give a Key
            1.3 Dictionary that stores Fruit as key and Quantity as Value. Let's edit quantity
            """);
        }

        private static string GetChoice()
        {
            Console.Write("Please enter your choice: ");
            return Console.ReadLine();
        }

        private static Dictionary<string, int> CreateDictionary(int howMuchPositions)
        {
            Dictionary<string, int> nameAndAgePair = new Dictionary<string, int>();
            string name;
            int age;

            for (int i = 0; i < howMuchPositions; i++)
            {
                Console.Write("Please enter name: ");
                name = Console.ReadLine();
                Console.Write($"Please enter age of {name}: ");
                age = Convert.ToInt32(Console.ReadLine());

                nameAndAgePair.Add(name, age);
            }

            return nameAndAgePair;
        }

        private static void PrintDictionaryNameAndAge(Dictionary<string, int> keyValuePairs)
        {
            foreach(KeyValuePair<string, int> keyValuePair in keyValuePairs)
            {
                Console.WriteLine($"{keyValuePair.Key} is {keyValuePair.Value} age old.");
            }
        }

        private static void PrintDictionaryCityAndCapital(Dictionary<string, string> keyValuePairs)
        {
            foreach(KeyValuePair<string, string> keyValuePair in keyValuePairs)
            {
                Console.WriteLine($"{keyValuePair.Key}");
            }
        }

        private static void PrintCapital(string country, Dictionary<string, string> keyValuePairs)
        {
            Console.WriteLine($"{country} capital is {keyValuePairs[country]}");
        }

        private static void AddFruitToDictionary(Dictionary<string, int> keyValuePairs)
        {
            string fruit = string.Empty;
            int quantity = 0;

            Console.Write("Please enter a fruit: ");
            fruit = Console.ReadLine();

            if (!keyValuePairs.ContainsKey(fruit))
            {
                Console.Write($"Please enter quantity of {fruit}: ");
                quantity = Convert.ToInt32(Console.ReadLine());

                keyValuePairs.Add(fruit, quantity);
            }
            else
            {
                Console.Write($"{fruit} already exists.\nPlease enter new {fruit} quantity: ");
                quantity = Convert.ToInt32(Console.ReadLine());

                keyValuePairs[fruit] = quantity;
            }
        }

        private static void PrintDictionaryFruitAndQuantity(Dictionary<string, int> keyValuePairs)
        {
            foreach (KeyValuePair<string, int> pair in keyValuePairs)
            {
                Console.WriteLine($"{pair.Key} -- {pair.Value} Qty.");
            }
        }
    }
}