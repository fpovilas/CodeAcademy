using System.Diagnostics;

namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PrintMenu();

            string choice = GetValue();

            switch (choice)
            {
                case "1.1":
                    int[] nums = GenerateRandomNumbers(10, 1, 10);

                    Print1DArray(nums);

                    break;
                case "1.2":
                    bool[] vals = GenerateRandomBools(5);

                    Print1DArray(vals);
                    break;
                case "1.3":

                    string pass = GeneratePassword(10);

                    Console.WriteLine($"Generated password is: {pass}");

                    break;
                case "1.4":

                    int[] ints;

                    for (int i = 0; i < 100; i++)
                    {
                        ints = GenerateRandomNumbers(6, 1, 6);

                        Console.WriteLine($"{i + 1, 3}. Random INT array sum: {SumArrayValues(ints)}");
                    }

                    break;
                case "1.5":
                    int randomNumber = GenerateRandomNumber(1, 100);

                    Console.Write("Please guess the number. Is it bigger than 50 (y/n): ");
                    string guess = Console.ReadLine();
                    string correctAnswer = randomNumber > 50 ? "y" : "n";

                    if(randomNumber > 50)
                    {
                        Console.WriteLine($"Random number is greater than 50. Number is {randomNumber}");
                        if (guess.ToLower() == correctAnswer)
                        { Console.WriteLine("You guessed correctly"); }
                        else
                        { Console.WriteLine("You guessed wrong"); }
                    }
                    else
                    {
                        Console.WriteLine($"Random number is greater than 50. Number is {randomNumber}");
                        if (guess.ToLower() == correctAnswer)
                        { Console.WriteLine("You guessed correctly"); }
                        else
                        { Console.WriteLine("You guessed wrong"); }
                    }

                    break;
                default:
                    Console.WriteLine("Wrong choice...");
                    break;
            }
        }

        private static void PrintMenu()
        {
            Console.WriteLine("""
            1.1 Method that generates random number from 1 to 10
            1.2 Generate random boolean values
            1.3 Generate password from random letters
            1.4 Generate random nums from 1 to 6 and sums them. Repeats 100 times
            1.5 Generate random number from 1 and 100 then lets you guess if it is > 50
            """);
        }

        private static string GetValue()
        {
            Console.Write("Please enter your choice: ");
            string choice = Console.ReadLine();
            return choice;
        }

        private static int[] GenerateRandomNumbers(int howMuch, int minNum, int maxNum)
        {
            Random random = new Random();
            int[] numbers = new int[howMuch];

            for(int i = 0; i < howMuch; i++)
            {
                numbers[i] = random.Next(minNum, maxNum + 1);
            }

            return numbers;
        }

        private static bool[] GenerateRandomBools(int howMuch)
        {
            Random random = new Random();
            bool[] vals = new bool[howMuch];

            for(int i = 0; i < howMuch; i++)
            {
                if (random.Next(0, 2) == 0)
                    vals[i] = false;
                else vals[i] = true;
            }

            return vals;
        }

        private static char GenerateRandomLetter()
        {
            char rndChar;
            Random random = new Random();

            rndChar = (char)(random.Next(0, 26) + 65);

            return rndChar;
        }

        private static string GeneratePassword(int passLength)
        {
            string pass = "";
            for(int i = 0; i < passLength; i++)
            {
                pass += GenerateRandomLetter();
            }

            return pass;
        }

        private static int SumArrayValues(int[] values)
        {
            int sum = 0;
            for(int i = 0; i < values.Length; i++)
            {
                sum += values[i];
            }

            return sum;
        }

        private static int GenerateRandomNumber(int minNum, int maxNum)
        {
            Random random = new Random();

            return random.Next(minNum, maxNum + 1);
        }

        // Prints INT 1D array
        private static void Print1DArray(int[] numbers)
        {
            for(int i = 0; i < numbers.Length; i++)
            {
                if (i < numbers.Length - 1)
                    Console.Write(numbers[i] + ", ");
                else Console.Write(numbers[i] + ".");
            }
        }

        // Prints Bool 1D array
        private static void Print1DArray(bool[] bools)
        {
            for (int i = 0; i < bools.Length; i++)
            {
                if (i < bools.Length - 1)
                    Console.Write(bools[i] + ", ");
                else Console.Write(bools[i] + ".");
            }
        }
    }
}