using System.Net;

namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Variables

            List<string> words;
            List<int> nums;
            double average;
            List<int> nums2;
            List<string> wordsToAscii;
            List<string> asciiSumIsEven;
            List<int> listOfNumbers;
            List<string> asciiSumIsPrime;

            #endregion

            PrintMenu();

            GetChoice(out string choice);

            switch (choice)
            {
                case "0":
                    Console.WriteLine("Wrong choice");
                    break;
                case "1.1":
                    words = new List<string>() { "Šiauliai", "Vilnius", "Trakai", "Aukštoji" };

                    PrintList(words);
                    break;
                case "1.2":
                    GenerateList(out nums, 50);

                    average = AverageOfList(nums);

                    Console.WriteLine($"{average:#.###}");
                    break;
                case "1.3":
                    GenerateList(out nums2, 10);

                    ListGreatedThan10(out List<int> greater, nums2);

                    foreach(int i in greater)
                        Console.WriteLine(i);

                    break;
                case "1.4":
                    wordsToAscii = new List<string> { "Povilas", "Tomas", "Ieva", "Petras" };

                    asciiSumIsEven = AsciiSumEven(wordsToAscii);

                    foreach(string i in asciiSumIsEven)
                        Console.WriteLine(i);

                    break;
                case "1.5":
                    GenerateList(out listOfNumbers, 5);

                    GetListFactorials(out List<int> factorials, listOfNumbers);

                    for(int i = 0; i < listOfNumbers.Count; i++)
                        Console.WriteLine($"{listOfNumbers[i]} factorial is {factorials[i]}");

                    break;
                case "1.6":
                    wordsToAscii = new List<string> { "Povilas", "Tomas", "Ieva", "Petras", "1", "u" };

                    asciiSumIsPrime = AsciiSumPrime(wordsToAscii);

                    if (asciiSumIsPrime.Count != 0)
                    {
                        foreach (string i in asciiSumIsPrime)
                            Console.WriteLine(i);
                    }
                    else { Console.WriteLine("\nNone of provided names have ASCII sum as Prime number"); }

                    break;
                default:
                    Console.WriteLine("There is only 6 tasks");
                    break;
            }
        }

        private static void PrintMenu()
        {
            Console.WriteLine("""
                1.1 Print strings and their length
                1.2 Calculate average of INT list
                1.3 Return list with numbers > 10
                1.4 Return strings that ASCII sum is even
                1.5 Takes INT list ant returns list of Factorials
                1.6 Return strings that ASCII sum is Prime Number
                """);
        }

        private static void GetChoice(out string choice)
        {
            choice = "Wrong";
            Console.Write("Please enter a choice: ");
            choice = Console.ReadLine();
        }

        private static void PrintList(List<string> list)
        {
            foreach (string item in list)
            {
                Console.WriteLine($"{item} has {item.Length} letters in it");
            }
        }

        private static void GenerateList(out List<int> list, int amountOfNums)
        {
            Random rand = new Random();
            list = new List<int>();

            for (int i = 0; i < amountOfNums; i++)
            {
                list.Add(rand.Next(1, 20));
            }
        }

        private static double AverageOfList(List<int> list)
        {
            double average = 0;
            foreach (int item in list)
            {
                average += item;
            }

            return average / list.Count;
        }

        private static void ListGreatedThan10(out List<int> list, List<int> ints)
        {
            list = new List<int>();
            foreach(int item in ints)
            {
                if(item > 10)
                    list.Add(item);
            }
        }

        private static List<string> AsciiSumEven(List<string> list)
        {
            int sum = 0;
            List<string> result = new List<string>();

            foreach(string item in list)
            {
                foreach(char c in item)
                {
                    sum += (int)c;
                }

                if(sum % 2 == 0)
                {
                    result.Add(item);
                }

                sum = 0;
            }

            return result;
        }

        private static void GetListFactorials(out List<int> factorials, List<int> toCount)
        {
            factorials = new List<int>();

            foreach(int num in toCount)
            {
                factorials.Add(CalculateFactorial(num));
            }
        }

        private static int CalculateFactorial(int num)
        {
            if(num == 0)
                return 1;
            else
                return num * CalculateFactorial(num - 1);
        }

        private static List<string> AsciiSumPrime(List<string> list)
        {
            int sum = 0;
            int divisions = 0;
            List<string> result = new List<string>();

            foreach (string item in list)
            {
                foreach (char c in item)
                {
                    sum += (int)c;
                }

                for (int i = 1; i < sum; i++)
                {
                    if(sum % i == 0)
                        divisions++;
                }

                if (divisions == 2)
                {
                    result.Add(item);
                }

                sum = 0;
                divisions = 0;
            }

            return result;
        }
    }
}