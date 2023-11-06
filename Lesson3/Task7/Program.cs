namespace Task7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Choose Task 7.1 by entering 1.\nChooce Task 7.2 by entering 2.\nYour choice: ");
            int choice = Convert.ToInt16(Console.ReadLine());
            if (choice == 1)
            {
                Console.Write("Please enter first number: ");
                int number1 = Convert.ToInt16(Console.ReadLine());
                Console.Write("Please enter second number: ");
                int number2 = Convert.ToInt16(Console.ReadLine());

                if (number1 > 0 && number2 > 0)
                    Console.WriteLine("Both numbers are positive");
                else if ((number1 < 0 && number2 > 0) || (number1 > 0 && number2 < 0))
                    Console.WriteLine("Only one number is positive");
                else
                    Console.WriteLine("Neither number is positive");
                    
            }
            else if (choice == 2)
            {
                Console.Write("Please enter first number: ");
                int number1 = Convert.ToInt16(Console.ReadLine());
                Console.Write("Please enter second number: ");
                int number2 = Convert.ToInt16(Console.ReadLine());
                Console.Write("Please enter third number: ");
                int number3 = Convert.ToInt16(Console.ReadLine());

                if (number1 == number2 && number1 == number3)
                    Console.WriteLine("All number are equal");
                else if ((number1 == number2 && number1 != number3) ||
                        (number1 == number3 && number2 != number3) ||
                        (number2 == number3 && number1 != number3))
                    Console.WriteLine("Two number are equal");
                else
                    Console.WriteLine("None of the number are equal");
            }
            else { Console.WriteLine("Wrong choice"); }
        }
    }
}