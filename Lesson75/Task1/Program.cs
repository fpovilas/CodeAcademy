using Task1.Class;

namespace Task1
{
    internal class Program
    {
        static void Main()
        {
            string? choice;
            double a, b;
            MathOperations mathOperations = new();
            do
            {
                Console.Clear();
                PrintMenu();
                Console.Write("Your choice: ");
                choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        a = GetValues(out b);
                        Console.WriteLine(mathOperations.Addition(a,b));
                        Console.ReadKey(true);
                        break;
                    case "2":
                        a = GetValues(out b);
                        Console.WriteLine(mathOperations.Subtraction(a, b));
                        Console.ReadKey(true);
                        break;
                    case "3":
                        a = GetValues(out b);
                        Console.WriteLine(mathOperations.Multiplication(a, b));
                        Console.ReadKey(true);
                        break;
                    case "4":
                        a = GetValues(out b);
                        Console.WriteLine(mathOperations.Division(a, b));
                        Console.ReadKey(true);
                        break;
                    case "5":
                        a = GetValue();
                        Console.WriteLine(mathOperations.PowerOf2(a));
                        Console.ReadKey(true);
                        break;
                    case "6":
                        a = GetValue();
                        Console.WriteLine(mathOperations.SquareRoot(a));
                        Console.ReadKey(true);
                        break;
                    default:
                        break;
                }
            } while (choice != "q");
        }

        public static void PrintMenu()
        {
            Console.WriteLine("""
                1. Addition
                2. Subtraction
                3. Multiplication
                4. Division
                5. Power Of 2
                6. SquareRoot
                q. Quit
                """);
        }

        private static double GetValues(out double b)
        {
            double a;
            do
            {
                Console.Clear();
                Console.Write("Please enter 1st value: ");
            }while(!double.TryParse(Console.ReadLine(), out a));

            do
            {
                Console.Clear();
                Console.Write("Please enter 2st value: ");
            } while (!double.TryParse(Console.ReadLine(), out b));

            return a;
        }

        private static double GetValue()
        {
            double a;
            do
            {
                Console.Clear();
                Console.Write("Please enter value: ");
            } while (!double.TryParse(Console.ReadLine(), out a));

            return a;
        }
    }
}