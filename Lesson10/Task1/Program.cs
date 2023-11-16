namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Variables

            byte choice;
            string input;
            int x;
            int y;

            #endregion

            PrintMenu();
            Console.Write("Please type your choice: ");
            input = Console.ReadLine();
            TryGetChoice(input, out choice);
            switch (choice)
            {
                case 0:
                    Console.WriteLine("Wrong choice...");
                    break;
                case 1:
                    Console.Write("Please type x value: ");
                    x = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Please type y value: ");
                    y = Convert.ToInt32(Console.ReadLine());

                    Swap(ref x, ref y);

                    Console.WriteLine($"Swaped values:\n  x is {x} and y is {y}");
                    break;
                case 2:
                    Console.Write("Please type value to increment: ");
                    x = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Please type value by how much to increment: ");
                    y = Convert.ToInt32(Console.ReadLine());

                    IncrementByN(x, ref y);

                    Console.WriteLine($"Incremented value is {y}");
                    break;
                case 3:
                    Console.Write("Please enter a string: ");
                    input = Console.ReadLine();

                    TrimAndCapitalize(ref input);

                    Console.WriteLine($"Trimed and Capitalize string: {input}");
                    break;
                default:
                    Console.WriteLine("There are only 3 tasks");
                    break;
            }
        }

        private static void PrintMenu()
        {
            Console.WriteLine("""
                1.1 Swaps number x to y and vice versa
                1.2 IncrementByN
                1.3 Trim string and Capitalize 1st letter of a string
                """);
        }

        private static void TryGetChoice(string v, out byte choice)
        {
            choice = 0;
            if (Byte.TryParse(v, out byte answer))
            {
                choice = answer;
            }
        }

        private static void Swap(ref int x, ref int y)
        {
            int temp = x;
            x = y;
            y = temp;
        }

        private static void IncrementByN(int x, ref int y)
        {
            y += x;
        }

        private static void TrimAndCapitalize(ref string s)
        {
            s = s.Trim();
            char[] charArray = s.ToCharArray();
            charArray[0] = Char.ToUpper(charArray[0]);
            s = new string(charArray);
        }
    }
}