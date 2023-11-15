using System.Runtime.CompilerServices;

namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Variables
            byte choice;
            string password, email, amountOfDollars;
            double amountOfUSD = 0, amountInEUR;
            const double rateOfUsdToEur = 0.92;
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
                    Console.Write("Please enter a password: ");
                    password = Console.ReadLine();

                    if (CheckIfPasswordIsValid(password))
                        Console.WriteLine("Password is long enought");
                    else
                        Console.WriteLine("Password is too short");

                    break;
                case 2:
                    Console.Write("Please enter your e.mail: ");
                    email = Console.ReadLine();

                    if (EmailIsValid(email)) Console.WriteLine("Your e.mail is valid.");
                    else Console.WriteLine("Your e.mail is not valid");

                    break;
                case 3:
                    Console.Write("Please enter amount of US dollars to convert to EUR: ");
                    amountOfDollars = Console.ReadLine();

                    amountOfUSD = ConvertToDouble(amountOfDollars);
                    amountInEUR = ConvertToEur(amountOfDollars, rateOfUsdToEur);
                    if (amountOfUSD != -1)
                        Console.WriteLine($"{amountOfUSD} USD converted to EUR is {amountInEUR:#.###}");
                    else
                        Console.WriteLine("Wrong formation");


                    break;
                default:
                    Console.WriteLine("There is only 3 task.");
                    break;
            }
        }

        private static double ConvertToEur(string amountOfDollars, double rateOfUSD)
        {
            double amountOfUSD = ConvertToDouble(amountOfDollars);

            return amountOfUSD * rateOfUSD;
        }

        private static double ConvertToDouble(string amountOfDollars)
        {
            if (amountOfDollars.Contains('.'))
                return Convert.ToDouble(amountOfDollars.Replace('.', ','));
            else if (amountOfDollars.Contains(','))
                return Convert.ToDouble(amountOfDollars);
            else if (Int32.TryParse(amountOfDollars, out int value))
                return Convert.ToDouble((decimal)value);
            else
                return -1;
        }

        private static bool EmailIsValid(string email)
        {
            if (email.Contains('@'))
            {
                int atLocation = email.IndexOf('@');
                string emailAfterAt = email.Substring(atLocation + 1, email.Length - (atLocation + 1));

                if (emailAfterAt.Contains('.') && emailAfterAt.IndexOf('.') != 0)
                {
                    return true;
                }
                else { return false; }
            }
            else return false;
        }

        private static bool CheckIfPasswordIsValid(string pass)
        {
            if (pass.Length >= 8) return true;
            else return false;
        }

        private static byte GetChoice()
        {
            byte number;
            if(Byte.TryParse(Console.ReadLine(), out number))
                return number;
            else return 0;
        }

        private static void PrintMenu()
        {
            Console.WriteLine("""
                1.1 Check if password is at least 8 characters long
                1.2 Check if string is a valid email
                1.3 Convert USD to EUR
                """);
        }
    }
}