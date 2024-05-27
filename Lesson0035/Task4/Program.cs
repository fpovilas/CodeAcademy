using System.Security;
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
                        //Hard to reproduce need INT16.MAXVALUE characters
                        throw new PathTooLongException("need INT16.MAXVALUE characters to reproduce. Fake PathTooLongException");
                    case 4:
                        readFile = new("D:\\Users\\Povka\\Coding\\Users\\Povka\\Coding\\");
                        break;
                    case 5:
                        throw new IOException("File needs to be locked. Fake IOException");
                    case 6:
                        throw new UnauthorizedAccessException("Fake UnauthorizedAccessException");
                    case 7:
                        readFile = new("test.txt");
                        break;
                    case 8:
                        throw new NotSupportedException("Fake NotSupportedException");
                    case 9:
                        throw new SecurityException("Fake SecurityException");
                    default:
                        Console.WriteLine("Wrong choice");
                        break;
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (PathTooLongException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (DirectoryNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (NotSupportedException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (SecurityException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
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
