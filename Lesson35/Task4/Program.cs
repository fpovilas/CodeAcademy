using Task4.Class;

namespace Task4
{
    internal class Program
    {
        static void Main()
        {
            PrintMenu();
            Console.Write("Your choice: ");
            int choice = GetChoice();

            try
            {
                switch (choice)
                {
                    case 1:
                        ReadFile readFile = new("");
                        break;
                    case 2:
                        readFile = new(null);
                        break;
                    case 3:
                        throw new NotImplementedException("Case not Implemented");
                    case 4:
                        throw new NotImplementedException("Case not Implemented");
                    case 5:
                        throw new NotImplementedException("Case not Implemented");
                    case 6:
                        throw new NotImplementedException("Case not Implemented");
                    case 7:
                        readFile = new("test.txt");
                        break;
                    case 8:
                        throw new NotImplementedException("Case not Implemented");
                    case 9:
                        throw new NotImplementedException("Case not Implemented");
                    default:
                        Console.WriteLine("Wrong choice");
                        break;
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (NotImplementedException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void PrintMenu()
        {
            Console.WriteLine("""
                1. ArgumentException
                2. ArgumentNullException
                3. PathTooLongException
                4. DirectoryNotFoundException
                5. IOException
                6. UnauthorizedAccessException
                7. FileNotFoundException
                8. NotSupportedException
                9. SecurityException
                """);
        }

        private static int GetChoice()
        {
            if(int.TryParse(Console.ReadLine(), out var choice))
                return choice;
            return 0;
        }
    }
}
