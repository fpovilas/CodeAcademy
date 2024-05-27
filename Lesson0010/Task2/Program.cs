using System.Runtime.InteropServices;

namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Variables

            byte choice;
            string input;
            int number;
            double divident, divisor;

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
                    GetUserData(out string firstName, out string lastName);
                    Console.WriteLine($"Hello to {firstName} {lastName}");
                    break;
                case 2:
                    do
                    {
                        Console.Write("Please enter a number: ");
                        input = Console.ReadLine();
                        if(int.TryParse(input, out number))
                        {
                            Console.WriteLine($"You entered: {number}. Is it greater than 100? {(number > 100 ? "Yes" : "No")}");
                        }
                        else { Console.WriteLine("You did not entered a number"); }
                    }
                    while (number <= 100);
                    break;
                case 3:
                    #region Task3 My Way
                    /*
                    Console.Write("Please enter a remainder to divinde a number 10: ");

                    if (double.TryParse(Console.ReadLine(), out double remParst)) { rem = remParst; }
                    else rem = null;


                    if (Divide(rem, out double? quoti))
                        Console.WriteLine($"Division was successful the Quotient is {quoti}");
                    else if (!Divide(rem, out quoti) && quoti == null)
                        Console.WriteLine("You did not entered a number");
                    else
                        Console.WriteLine("Division from zero is impossible");
                    */
                    #endregion
                    Console.Write("Please enter divindet: ");
                    divident = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Please enter divisor: ");
                    divisor = Convert.ToDouble(Console.ReadLine());

                    if (Divide(divident, divisor, out int quoti, out int rem))
                        Console.WriteLine($"Quotient: {quoti} and Remaider: {rem}");
                    else
                        Console.WriteLine("Division from zero is impossible");

                    break;
                default:
                    Console.WriteLine("There are only 3 tasks");
                    break;
            }
        
        }

        private static void PrintMenu()
        {
            Console.WriteLine("""
                2.1 out First name and Last name
                2.2 Stop when number is greater than 100
                2.3 Division
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

        private static void GetUserData(out string firstName, out string lastName)
        {
            Console.Write("Please enter your first name: ");
            firstName = Console.ReadLine();
            Console.Write("Please enter your last name: ");
            lastName = Console.ReadLine();
        }

        private static bool Divide(double divident, double divosr, out int quotient, out int remainder)
        {
            quotient = 0;
            remainder = 0;

            double quoti;
            if (divosr == 0)
                return false;
            else
            {
                quoti = divident / divosr;

                quotient = (int)quoti;
                remainder = (int)((quoti - quotient) * divosr);

                return true;
            }
        }

        #region Divide My Way
        /*
        private static bool Divide(double? remainder, out double? quotient)
        {
            quotient = null;
            if (remainder != 0 && remainder != null)
            {
                quotient = 10 / (double)remainder;
                return true;
            }
            else
                return false;
        }
        */
        #endregion
    }
}