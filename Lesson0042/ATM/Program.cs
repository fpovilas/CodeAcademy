using ATM.Class;
using ATM.Exceptions;

namespace ATM
{
    internal class Program
    {
        static void Main()
        {
            #region Global values

            bool isLoggedIn = false;
            bool isBlocked = false;
            User? user = null;
            Account? acc = null;
            string? cardNumber = string.Empty;
            int amount = 0;

            #endregion

            #region Hard Coded Paths

            string pathToUsers = @"D:\Projektai\Programavimas\CodeAcademy\Lesson42\ATM\DB\Users.txt";
            string pathToTransaction = @"D:\Projektai\Programavimas\CodeAcademy\Lesson42\ATM\DB\Transactions\";

            #endregion

            List<User> users = GetUsers(pathToUsers);

            do // Main Loop (Log in, Pass retries, Logged in)
            {
                ClearWindowPrintLogo();
                Console.Write("Please enter a Card Number: ");

                // Trying to get CardNumber
                try { cardNumber = GetCardNumber(); }
                catch (CardEmptyException exception)
                {
                    PrintDarkRedTextWithPause(exception.Message);
                    continue;
                }

                // Trying to get User
                try { user = GetUser(users, cardNumber); }
                catch (UserNotFoundException exception)
                {
                    PrintDarkRedTextWithPause(exception.Message);
                    continue;
                }

                // Handling GetAccount().GetIsBlocked() null
                if(user != null)
                {
                    acc = user.GetAccount();
                    if (acc != null) { isBlocked = acc.GetIsBlocked(); }
                }
                else
                { 
                    PrintDarkRedTextWithPause("Something went wrong please try again");
                    continue;
                }

                // Loop for handling password retries
                int retries = 0;
                while (!isBlocked)
                {
                    ClearWindowPrintLogo();

                    Console.Write("Please enter a Password: ");
                    string password = GetPassword();

                    // Handle GetAccount().GetPassword() null
                    string? pass = null;
                    acc = user.GetAccount();
                    if (acc != null) { pass = acc.GetPassword(); }
                    else
                    { 
                        PrintDarkRedTextWithPause("Something went wrong");
                        continue;
                    }

                    if (password == pass)
                    {
                        isLoggedIn = true;
                        break;
                    }
                    else
                    {
                        PrintDarkRedTextWithPause("Wrong password",true);
                        retries++;
                        if (retries == 3)
                        {
                            if(acc != null)
                            {
                                acc.SetIsBlocked();
                                isBlocked = acc.GetIsBlocked();
                            }
                        }
                    }
                    
                }

                if (isBlocked && !isLoggedIn)
                {
                    PrintDarkRedTextWithPause("Your card is blocked. Please go to your nearest bank to unblock it.", true);
                    continue;
                }

                do
                {
                    ClearWindowPrintLogo();

                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.WriteLine($"Hello, {user!.GetName()}");
                    Console.ResetColor();

                    PrintLoggedInMenu();

                    int choice = GetChoice();

                    switch (choice)
                    {
                        case 1:
                            ClearWindowPrintLogo();

                            //Handle GetAccount().GetMoneyInAccount() null
                            if(user != null)
                            {
                                acc = user.GetAccount();
                                if(acc != null)
                                {
                                    Console.WriteLine($"Your balance: {acc.GetMoneyInAccount()}€");
                                }
                            }
                            else
                            {
                                PrintDarkRedTextWithPause("Something went wrong");
                                continue;
                            }
                            Console.ReadKey(true);
                            break;
                        case 2:
                            ClearWindowPrintLogo();

                            user.ReadFromFile(pathToTransaction);

                            Console.WriteLine("Last 5 Transactions:");
                            if (user.GetTransactions().Count != 0)
                            {
                                List<Transaction> orderedTransactions =
                                [
                                    .. user.GetTransactions()
                                           .OrderByDescending(date => date.GetTransactionTime())
                                ];

                                GetTransactionCount(orderedTransactions, out int num);

                                for(int i = 0; i < num; i++)
                                {
                                    Console.WriteLine(orderedTransactions[i].ToString());
                                }
                            }
                            else { Console.WriteLine("There is no transaction history."); }
                            Console.ReadLine();
                            break;
                        case 3:
                            ClearWindowPrintLogo();

                            Console.Write("Please type the amount that you want to withdraw: ");
                            amount = GetChoice();

                            acc = user.GetAccount();
                            if (acc != null)
                            {
                                if (acc.WithdrawMoney(amount))
                                {
                                    Console.WriteLine($"You have withdrawn {amount}€. Current balance {acc.GetMoneyInAccount()}€");
                                    Console.ReadKey(true);
                                }
                                else { Console.WriteLine("Transaction failed..."); }
                            }
                            else
                            {
                                PrintDarkRedTextWithPause("Something went wrong");
                                continue;
                            }
                            break;
                        case 4:
                            ClearWindowPrintLogo();

                            Console.Write("Please type the amount that you want to deposit: ");
                            amount = GetChoice();

                            acc = user.GetAccount();
                            if (acc != null)
                            {
                                if (acc.DepositMoney(amount))
                                {
                                    Console.WriteLine($"You have deposited {amount}€. Current balance {acc.GetMoneyInAccount()}€");
                                    Console.ReadKey(true);
                                }
                                else { Console.WriteLine("Deposit failed..."); }
                            }
                            else
                            {
                                PrintDarkRedTextWithPause("Something went wrong");
                                continue;
                            }
                            break;
                        case 5:
                            WriteUserDataToFile(pathToUsers, users);
                            isLoggedIn = false;
                            break;
                        default:
                            Console.WriteLine($"Wrong Choice. {choice}");
                            break;
                    }
                } while (isLoggedIn);

            } while (!isLoggedIn);
        }

        #region Get functions

        private static string? GetCardNumber()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            string? cardNum = Console.ReadLine();
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

        private static User? GetUser(List<User> users, string? cardNum)
        {
            User? newUser = null;

            newUser = users.FirstOrDefault(usr => usr.GetAccount()!.GetCardNumber() == cardNum);

            if (newUser == null)
                throw new UserNotFoundException("There is no user in list. Please Try again.");

            return newUser;
        }

        private static int GetChoice()
        {
            if (int.TryParse(Console.ReadLine(), out int choice))
                return choice;
            return 0;
        }

        private static List<User> GetUsers(string pathToFile)
        {
            List<User> newListOfUsers = [];

            using StreamReader streamReader = new(pathToFile);
            List<string> listOfUsers = [.. streamReader.ReadToEnd().Replace("\r\n", ",").Split(',')];

            for (int i = 0; i < listOfUsers.Count; i += 4)
            {
                User usr = new(listOfUsers[i]);
                Account acc = new(listOfUsers[i + 1], Convert.ToDouble(listOfUsers[i + 2]), listOfUsers[i + 3]);
                usr.SetAccount(acc);

                newListOfUsers.Add(usr);
            }

            return newListOfUsers;
        }

        private static void GetTransactionCount(List<Transaction> transactions, out int num)
        {
            if (transactions.Count < 0)
                num = transactions.Count;
            else { num = 5; }
        }

        #endregion

        #region Print functions

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

        private static void PrintDarkRedTextWithPause(string textToPrint, bool printInList = false)
        {
            if(printInList)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine(textToPrint);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write(textToPrint);
            }
            Console.ResetColor();
            Console.ReadKey(true);
        }

        #endregion

        #region Helper functions

        public static void WriteUserDataToFile(string path, List<User> users)
        {
            List<User> workableUserList = [.. users.OrderBy(usr => usr.GetName())];
            using (StreamWriter streamWriter = new(path))
            {
                for (int i = 0; i < workableUserList.Count; i++)
                {
                    if (i + 1 == workableUserList.Count)
                        streamWriter.Write(workableUserList[i].ToStringToFile());
                    else { streamWriter.WriteLine(workableUserList[i].ToStringToFile()); }
                }
            }
            Console.WriteLine("Data has been written.");
            Console.ReadKey(true);
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

        private static void ClearWindowPrintLogo()
        {
            Console.Clear();
            Logo();
        }

        #endregion

        // Add editing file
        // Handle all Null exceptions
    }
}