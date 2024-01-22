using ATM.Class;
using ATM.Exceptions;
using System.Threading.Channels;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ATM
{
    internal class Program
    {
        static void Main()
        {
            bool isLoggedIn = false;

            /*List<User> users = [
                    new("Povilas", new Account("1234", 100, "123456789")),
                    new("Petras", new Account("4321", 1000, "987654321"))
                ];*/
            string pathToUsers = @"D:\Projektai\Programavimas\CodeAcademy\Lesson42\ATM\DB\Users.txt";
            List<User> users = GetUsers(pathToUsers);

            User? user = null;
            string cardNumber = string.Empty;

            int amount = 0;

            do // Loop for log in
            {
                Console.Clear();
                Logo();
                Console.Write("Please enter a Card Number: ");

                // Trying to get CardNumber
                try { cardNumber = GetCardNumber(); }
                catch (CardEmptyException exception)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine(exception.Message);
                    Console.ReadKey(true);
                    Console.ResetColor();
                    continue;
                }

                // Trying to get User
                try { user = GetUser(users, cardNumber); }
                catch (UserNotFoundException exception)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine(exception.Message);
                    Console.ReadKey(true);
                    Console.ResetColor();
                    continue;
                }

                bool isBlocked = user!.GetAccount().GetIsBlocked();
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
                            isLoggedIn = true;
                            break;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("Wrong password");
                            Console.ReadKey(true);
                            Console.ResetColor();
                            retries++;
                            if (retries == 3)
                            {
                                user.GetAccount().SetIsBlocked();
                                isBlocked = user.GetAccount().GetIsBlocked();
                            }
                        }
                    }
                }
                if (isBlocked && !isLoggedIn)
                {
                    Console.WriteLine("Your card is blocked. Please go yo nearest bank to unblock it.");
                    Console.ReadKey(true);
                }

                do
                {
                    Console.Clear();
                    Logo();

                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.WriteLine($"Hello, {user!.GetName()}");
                    Console.ResetColor();

                    PrintLoggedInMenu();

                    int choice = GetChoice();

                    switch (choice)
                    {
                        case 1:
                            Console.Clear();
                            Logo();

                            Console.WriteLine($"Your balance: {user.GetAccount().GetMoneyInAccount()}€");
                            Console.ReadKey(true);
                            break;
                        case 2:
                            Console.Clear();
                            Logo();

                            Console.WriteLine("Last 5 Transactions:");
                            if (user.GetTransactions().Count != 0)
                            {
                                int counter = 0;
                                foreach(Transaction trans in user!.GetTransactions().OrderByDescending(date => date.GetTransactionTime()))
                                {
                                    if(counter < 5)
                                    {
                                        Console.WriteLine(trans.ToString());
                                        counter++;
                                    }
                                    else { break; }
                                }
                            }
                            else { Console.WriteLine("There is no transaction history."); }
                            Console.ReadLine();
                            break;
                        case 3:
                            Console.Clear();
                            Logo();

                            Console.Write("Please type the amount that you want to withdraw: ");
                            amount = GetChoice();
                            user.GetAccount().WithdrawMoney(amount);

                            Console.WriteLine($"You have withdrawn {amount}€. Current balance {user.GetAccount().GetMoneyInAccount()}€");
                            user.SetTransaction(new Transaction(amount, "Withdraw"));
                            Console.ReadKey(true);
                            break;
                        case 4:
                            Console.Clear();
                            Logo();

                            Console.Write("Please type the amount that you want to deposit: ");
                            amount = GetChoice();
                            user.GetAccount().DepositMoney(amount);

                            Console.WriteLine($"You have deposited {amount}€. Current balance {user.GetAccount().GetMoneyInAccount()}€");
                            user.SetTransaction(new Transaction(amount, "Deposit"));
                            Console.ReadKey(true);
                            break;
                        case 5:
                            string path = @"D:\Projektai\Programavimas\CodeAcademy\Lesson42\ATM\DB\Users.txt";
                            user.WriteToFile(path);
                            isLoggedIn = false;
                            break;
                        default:
                            Console.WriteLine($"Wrong Choice. {choice}");
                            break;
                    }
                } while (isLoggedIn);

            } while (!isLoggedIn);
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

        private static int GetChoice()
        {
            if(int.TryParse(Console.ReadLine(), out int choice))
                return choice;
            return 0;
        }

        private static List<User> GetUsers(string pathToFile)
        {
            List <User> newListOfUsers = [];

            using StreamReader streamReader = new(pathToFile);
            List<string> data = [.. streamReader.ReadToEnd().Replace("\r\n", ",").Split(',')];
            for (int i = 0; i < data.Count; i += 4)
            {
                newListOfUsers.Add(new User(data[i], new Account(data[i + 1], Convert.ToDouble(data[i + 2]), data[i + 3])));
            }

            return newListOfUsers;
        }

        private static void PrintLoggedInMenu()
        {
            Console.WriteLine("""
                1. Show available money
                2. Show 5 last transactions
                3. Withdraw money
                4. Deposit money
                5. Log out
                """);
        }
    }
}