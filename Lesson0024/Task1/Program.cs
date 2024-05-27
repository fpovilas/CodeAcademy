using Task1.Class;

namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PrintMenu();
            int choice = GetChoice();

            switch (choice)
            {
                case 1:

                    Console.WriteLine("Person Class:");

                    Person povilas = new("Povilas", 26);
                    Console.WriteLine($"\t{povilas.Name} is {povilas.Age}");

                    Person ieva = new("Ieva", 31, 176);
                    Console.WriteLine($"\t{ieva.Name} is {ieva.Age}. Height is {ieva.Height}");

                    break;
                case 2:

                    Console.WriteLine("School Class:");

                    School geguziai = new("Gegužių progrimnazija", "Šiauliai");
                    Console.WriteLine($"\t{geguziai.Name} is in {geguziai.City}");

                    School romuva = new("Romuvos gimnazija", "Šiauliai", 479);
                    Console.WriteLine($"\t{romuva.Name} is in {romuva.City}" +
                                     $" and it has {romuva.StudentNumber} students");

                    break;
                default:
                    Console.WriteLine("Wrong choice...");
                    break;
            }
        }

        private static void PrintMenu()
        {
            Console.WriteLine("""
                1. Example with Person Class
                2. Example with School Class
                """);
        }

        private static int GetChoice()
        {
            Console.WriteLine("Please enter your choice");
            if(int.TryParse(Console.ReadLine(), out var choice))
            {
                return choice;
            }
            return 0;
        }
    }
}