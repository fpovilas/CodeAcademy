using Task2.Class;

namespace Task2
{
    internal class Program
    {
        static void Main()
        {
            List<Person> people =
            [
                new("Povilas",
                    [
                        new("Hela", 3),
                        new("Snow", 5)
                    ]),
                new("Ieva",
                    [
                        new("Agota", 1),
                        new("Leggo", 0),
                        new("Cypsius", 13)
                    ]),
                new("Petras",
                    [
                        new("Snitch", 6),
                        new("Aga", 2),
                        new("Dėžius", 15)
                    ]),
                new("Kostas",
                    [
                        new("Slithers", 9),
                        new("Andže", 6)
                    ]),
            ];

            Separator();

            List<Animal> animals =
                people.SelectMany(p => p.Animals).ToList();
            PrintText("List of animals: ");
            PrintList(animals);

            Separator();

            PrintText("List of animals whos name starts with A: ");
            PrintList(animals
                        .Select(animal => animal)
                        .Where(animal => animal.Name.StartsWith('A')).ToList());

            Separator();

            PrintText("List of animals whos name starts with A and age > 5 y/o: ");
            PrintList(animals
                        .Select(animal => animal)
                        .Where(animal => animal.Name.StartsWith('A') &&
                               animal.Age > 5)
                        .ToList());

            Separator();

            List<string> listOfStrings = ["Zodis", "ZODIS", "zoDIS", "zodis"];
            PrintText("Default List<string>: ");
            PrintList(listOfStrings);
            PrintText("Print only UPPERCASE words: ");
            //Func<string,string> upperCaseString
        }

        private static void PrintList<Type>(List<Type> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (i < list.Count - 1)
                    Console.Write($"{list[i]}, ");
                else { Console.WriteLine($"{list[i]}."); }
            }
        }

        private static void PrintText(string text)
        {
            Console.ForegroundColor= ConsoleColor.Magenta;
            Console.Write(text);
            Console.ResetColor();
        }

        private static void Separator()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------");
            Console.ResetColor();
        }
    }
}
/*
 * Create a Person class with a name and a list of animals (also a new class, the animals have only a name). Create a list with Person objects and lists of animals inside.
 ** With LINQ Select and SelectMany, create a list consisting of all the animals in the list.
 *** Another list will consist only of animals whose names start with the letter A.
 *** Add the age int Age to the Pet class, make another list of animals with names starting with the letter A and aged over 5 years.
 * Write a method that accepts one string parameter. Write a LINQ function to return words that are all uppercase.
 */