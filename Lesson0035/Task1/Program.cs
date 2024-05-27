namespace Task1
{
    internal class Program
    {
        static void Main()
        {
            PrintMenu();
            try
            {
                Console.WriteLine("Your choice: ");
                int choice = int.Parse(Console.ReadLine()!);
                switch(choice)
                {
                    case 1:
                        Convert.ToDouble(DateTime.Now);
                        break;
                    case 2:
                        Convert.ToDouble("Labas");
                        break;
                    default:
                        Console.WriteLine("Wrong choice");
                        break;
                };
            }
            catch(InvalidCastException exception)
            {
                Console.WriteLine(exception.Message);
            }
            catch(FormatException exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        private static void PrintMenu()
        {
            Console.WriteLine("""
                1. Get InvalidCastException
                2. Get FormatException
                """);
        }
    }
}
