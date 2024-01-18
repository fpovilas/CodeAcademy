using ATM.Class;
using ATM.Exceptions;

namespace ATM
{
    internal class Program
    {
        static void Main()
        {
            bool isLoggedIn = false;

            List<User> users = [
                    new("Povilas", new Account("1234", 100, "123456789")),
                    new("Petras", new Account("4321", 1000, "987654321"))
                ];

            do
            {
                Console.Clear();
                Logo();
                Console.Write("Please enter a Card Number: ");

                string cardNumber = string.Empty;

                try { cardNumber = GetCardNumber(); }
                catch(CardEmptyException exception)
                {
                    Console.WriteLine(exception.Message);
                    Console.ReadKey(true);
                    continue;
                }
                
                User? user = null;

                try { user = GetUser(users, cardNumber); }
                catch(UserNotFoundException exception)
                { 
                    Console.WriteLine(exception.Message);
                    Console.ReadKey(true);
                    continue;
                }

                if (cardNumber == user!.GetAccount().GetCardNumber())
                {
                    bool isBlocked = false;
                    int retries = 0;

                    while (!isBlocked)
                    {
                        Console.Clear();
                        Logo();
                        Console.Write("Please enter a Password: ");
                        string password = GetPassword();

                        if (user.GetAccount().GetIsBlocked())
                        {
                            isBlocked = user.GetAccount().GetIsBlocked();
                            continue;
                        }
                        else
                        {
                            if (password == user.GetAccount().GetPassword())
                            {
                                Console.WriteLine("Welcome");
                                isLoggedIn = true;
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Wrong password");
                                Console.ReadKey(true);
                                retries++;
                                if (retries == 3)
                                {
                                    user.GetAccount().SetIsBlocked();
                                    isBlocked = user.GetAccount().GetIsBlocked();
                                }
                            }
                        }
                    }
                }
                else { Console.WriteLine("Wrong card number"); }
            }while (!isLoggedIn);
        }

        private static void Logo()
        {
            Console.WriteLine("""
            ╔═══════════════════╗
            ║ ╔═══╗╔════╗╔═╗╔═╗ ║
            ║ ║╔═╗║║╔╗╔╗║║║╚╝║║ ║
            ║ ║║ ║║╚╝║║╚╝║╔╗╔╗║ ║
            ║ ║╚═╝║  ║║  ║║║║║║ ║
            ║ ║╔═╗║ ╔╝╚╗ ║║║║║║ ║
            ║ ╚╝ ╚╝ ╚══╝ ╚╝╚╝╚╝ ║
            ╚═══════════════════╝
            """);
        }

        private static string GetCardNumber()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            string cardNum = Console.ReadLine()!;
            Console.ResetColor();

            if (cardNum == string.Empty)
                throw new CardEmptyException($"CardNumber is empty. Please try again.");

            return cardNum;
        }

        private static string GetPassword()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            string pass = Console.ReadLine()!;
            Console.ResetColor();
            return pass;
        }

        private static User? GetUser(List<User> users, string cardNum)
        {
            User? newUser = null;
            foreach (User user in users)
            {
                if (cardNum == user.GetAccount().GetCardNumber())
                    newUser = user;
            }

            if(newUser == null)
                throw new UserNotFoundException("There is no user in list. Please Try again.");

            return newUser;
        }
    }
}