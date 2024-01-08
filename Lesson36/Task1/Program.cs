using Task1.Class;

namespace Task1
{
    internal class Program
    {
        static void Main()
        {
            #region Variables

            int number;
            int numberToCheckAgainst;
            string sentence;
            string fullName;
            string yearOfBirth;
            string domain;
            bool stopLoop = false;

            #endregion

            do
            {
                PrintMenu();
                int choice = GetChoice();
                switch (choice)
                {
                    case 1:
                        Console.Write("Please enter a number: ");
                        number = int.Parse(Console.ReadLine() ?? "0");
                        bool isPositive = number.IsPositive();
                        if (isPositive)
                            Console.WriteLine($"{number} is positive");
                        else { Console.WriteLine($"{number} is negative"); }
                        break;
                    case 2:
                        Console.Write("Please enter a number: ");
                        number = int.Parse(Console.ReadLine() ?? "0");
                        bool isEven = number.IsEven();
                        if (isEven)
                            Console.WriteLine($"{number} is even");
                        else { Console.WriteLine($"{number} is odd"); }
                        break;
                    case 3:
                        Console.Write("Please enter a number: ");
                        number = int.Parse(Console.ReadLine() ?? "0");
                        Console.Write("Please enter a number to check against: ");
                        numberToCheckAgainst = int.Parse(Console.ReadLine() ?? "0");
                        bool isGreater = number.IsGreater(numberToCheckAgainst);
                        if (isGreater)
                            Console.WriteLine($"{number} is greater than {numberToCheckAgainst}");
                        else { Console.WriteLine($"{number} is lower than {numberToCheckAgainst}"); }
                        break;
                    case 4:
                        Console.Write("Please enter a sentence: ");
                        sentence = Console.ReadLine() ?? string.Empty;
                        bool containsSpace = sentence.ContainsSpace();
                        if (containsSpace)
                            Console.WriteLine($"{sentence} contains spaces");
                        else { Console.WriteLine($"{sentence} doesn't contain spaces"); }
                        break;
                    case 5:
                        Console.Write("Enter your full name: ");
                        fullName = Console.ReadLine() ?? string.Empty;
                        Console.Write("Enter you year of birth: ");
                        yearOfBirth = Console.ReadLine() ?? string.Empty;
                        Console.Write("Enter domain: ");
                        domain = Console.ReadLine() ?? string.Empty;

                        fullName = fullName.Split(' ')[0] + fullName.Split(' ')[1];

                        string email = fullName.CreateEmail(yearOfBirth, domain);

                        Console.WriteLine($"Your email: {email}");
                        break;
                    case 6:
                        List<string> words = ["Labas", "Žodis", "Povilas"];

                        Console.Write("What are we looking for?: ");
                        string wordToSearch = Console.ReadLine() ?? string.Empty;

                        string? zodis = words.FindAndReturnIfEqual(wordToSearch);

                        if (zodis != null)
                            Console.WriteLine(zodis);
                        else { Console.WriteLine("No match were found"); }
                        break;
                    case 7:
                        List<string> list = ["Labas", "Rytas", "Lietuva"];
                        List<string> newList = list.EveryOtherValue();

                        Console.WriteLine("All List:");
                        foreach (string word in list)
                            Console.WriteLine(word);

                        Console.WriteLine("EveryOtherValue List:");
                        foreach (string item in newList)
                            Console.WriteLine(item);
                        break;
                    case 8:
                        Console.WriteLine("You cannot extend System.IO.File class because File class is Static");
                        //https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/extension-methods#extending-predefined-types
                        //https://stackoverflow.com/questions/5311990/extend-file-class
                        //There is contradiction between these two sites
                        break;
                    default:
                        Console.WriteLine($"Wrong choice... ({choice})");
                        stopLoop = true;
                        break;

                }
            } while (!stopLoop);
        }

        private static void PrintMenu()
        {
            Console.WriteLine("""
            1. Check if int is Positive or Negative
            2. Check if int is Even or Odd
            3. Check if number is grater than given
            4. Check if string contains spaces
            5. Create email
            6. Returns searched value if it is in List<T>
            7. Return new List<T> of every other value in List<T>
            8. Return every other line from a text file
            """);
        }

        private static int GetChoice()
        {
            Console.Write("Your choice: ");
            if(int.TryParse(Console.ReadLine(), out int choice))
                return choice;
            return 0;
        }
    }
}
/*
 * Write an extension method for integers that returns a variable of type bool indicating whether the number was positive or negative.
 * Write an extension method for integers that returns a variable of type bool indicating whether the number was even or not.
 * Write an extension method for integers that returns a variable of type bool indicating whether the number passed in the parameter is greater or not.
 * Write an extension method for the string type that will return a variable of type bool indicating whether a sentence contains spaces or not.
 * Write an extension method for a string type with the parameters full name, yearOfBirth and domain, the method will return the result as an email address. For example: "vardenispavardenis1990@gmail.com"
 * Write an extension method FindAndReturnIfEqual for type List<T> that accepts an object of type T as a parameter and returns the same if it exists in the list.
 * Write an extension method EveryOtherWord for the List<T> type that returns a list consisting of every second element.
 * Would it be possible to create extension methods for the System.IO.File class? For example to create functionality that returns every second line from a text file.
 */