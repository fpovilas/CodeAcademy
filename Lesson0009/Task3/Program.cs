namespace Task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Variables
            byte choice;
            int fibonnaci;
            ulong factorial = 1;
            #endregion

            PrintMenu();
            Console.Write("Please enter your choice: ");
            choice = GetChoice();

            switch (choice)
            {
                case 0:
                    Console.WriteLine("You made a wrong choice.");
                    break;
                case 1:
                    Console.Write("Please enter the number: ");
                    factorial = Convert.ToUInt64(Console.ReadLine());

                    Console.WriteLine($"Factorial of {factorial} is {CalculateFactorial(factorial)}");
                    break;
                case 2:
                    Console.Write("Please enter the number: ");
                    fibonnaci = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Fibonacci Sequennce: ");
                    CalculateFibonacciSequence(0, 1, 1, fibonnaci);
                    break;
                default:
                    Console.WriteLine("There is only 2 task.");
                    break;
            }
        }

        private static void PrintMenu()
        {
            Console.WriteLine("""
                2.1 Factorial
                2.2 Fibonnaci sequence
                """);
        }

        private static byte GetChoice()
        {
            byte number;
            if (Byte.TryParse(Console.ReadLine(), out number))
                return number;
            else return 0;
        }

        private static ulong CalculateFactorial(ulong factor)
        {
            if(factor == 0)
                return 1;

            return factor * CalculateFactorial(--factor);
        }

        private static void CalculateFibonacciSequence(int firstNum, int secondNum, int counter, int num) // From internet
        {
            Console.Write($"{firstNum} ");
            if(counter < num)
                CalculateFibonacciSequence(secondNum, firstNum + secondNum, counter + 1, num);
        }
    }    
}