namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Variables

            string choice;
            int sum = 0;
            int n, power;
            float mean;

            #endregion

            PrintMenu();
            Console.Write("Please enter your choice: ");
            choice = Console.ReadLine();

            GetChoice(choice, out byte num);

            switch (num)
            {
                case 0:
                    Console.WriteLine("You entered not a number, Sir.");
                    break;
                case 1:
                    PrintEven1To100();
                    break;
                case 2:
                    GetNumber(out n);

                    PrintSum1ToNth(n);
                    break;
                case 3:
                    GetNumber(out n);

                    PrintPower1ToNth(n);
                    break;
                case 4:
                    GetNumber(out n);

                    PrintMean1ToNth(n);
                    break;
                case 5:
                    GetNumber(out n);

                    PrintStars(n);
                    break;
                case 6:
                    PrintDivisibleFrom3From1To100();
                    break;
                default:
                    Console.WriteLine("There is only 6 tasks...");
                    break;
            }

        }

        #region Functions
        private static void PrintMenu()
        {
            Console.WriteLine("""
                1.1 Even numbers to 100
                1.2 Sum of all numbers from 1 to n-th
                1.3 Power of numbers from 1 to n-th
                1.4 Arithmetic mean of numbers from 1 to n-th
                1.5 Column of stars (*)
                1.6 All numbers from 1 to 100 that are divisable from 3
                """);
        }

        private static void GetChoice(string choice, out byte num)
        {
            num = 0;
            if (Byte.TryParse(choice, out byte answer))
            {
                num = answer;
            }
        }

        private static void GetNumber(out int num)
        {
            num = 0;
            Console.Write("Please enter a number: ");
            num = Convert.ToInt32(Console.ReadLine());
        }

        private static void PrintEven1To100()
        {
            for (int i = 0; i <= 100; i += 2)
                Console.WriteLine($"A number {i} is even");
        }

        private static void PrintSum1ToNth(int num)
        {
            int sum = 0;
            for (int i = 1; i <= num; i++)
                sum += i;

            Console.WriteLine($"Sum from 1 to {num} is {sum}");
        }

        private static void PrintPower1ToNth(int n)
        {
            int power;
            for (int i = 1; i <= n; i++)
            {
                power = 1;
                for (int j = 1; j <= 2; j++)
                    power *= i;

                Console.WriteLine($"Power of {i,3} is {power,3}");
            }
        }

        private static void PrintMean1ToNth(int n)
        {
            int sum = 0;
            
            for (int i = 1; i <= n; i++)
                sum += i;

            float mean = (float)sum / (float)n;

            Console.WriteLine($"Arithmetic mean of {sum} when there is {n} numbers is {mean:#.###}");
        }

        private static void PrintStars(int n)
        {
            for (int i = 0; i < n; i++)
                Console.WriteLine('*');
        }

        private static void PrintDivisibleFrom3From1To100()
        {
            for (int i = 1; i <= 100; i ++)
                for(; i % 3 == 0;)
                {
                    Console.WriteLine($"A number {i} is divisable from 3. You get {i / 3}");
                    break;
                }
        }

        #endregion
    }
}