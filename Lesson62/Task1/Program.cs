using System.Text;
using Task1.Database;
using Task1.Database.Models;

namespace Task1
{
    internal class Program
    {
        private static readonly ATMContext aTMContext = new();
        static void Main()
        {
            bool isDone = false;

            do
            {
                PrintStartMenu();
                UserChoice(out int initialChoice);

                switch ((PossibleChoice)initialChoice)
                {
                    case PossibleChoice.Create:
                        PrintMenu();
                        UserChoice(out int createChoice);
                        CreateSwitchCase(createChoice);
                        break;
                    case PossibleChoice.Read:
                        PrintMenu();
                        UserChoice(out int readChoice);
                        ReadSwitchCase(readChoice);
                        break;
                    case PossibleChoice.Update:
                        PrintMenu();
                        UserChoice(out int updateChoice);
                        UpdateSwitchCase(updateChoice);
                        break;
                    case PossibleChoice.Delete:
                        Account accToRemove = new();
                        UserChoice(out int ID);
                        accToRemove.ID = ID;
                        aTMContext.Accounts.Remove(accToRemove);
                        break;
                    case PossibleChoice.Exit:
                        isDone = true;
                        break;
                    default:
                        PrintRed("Something went wrong");
                        break;
                }
            }
            while (!isDone);            
        }

        private static void PrintLogo()
        {
            Console.WriteLine("""

                ┏┓┏┳┓┳┳┓
                ┣┫ ┃ ┃┃┃
                ┛┗ ┻ ┛ ┗
                ┏┓┳┓┳┳┳┓
                ┃ ┣┫┃┃┃┃
                ┗┛┛┗┗┛┻┛
                        
                """);
        }

        private static void PrintStartMenu()
        {
            Console.Clear();
            PrintLogo();
            Console.WriteLine("""
                1. Create
                2. Read
                3. Update
                4. Delete
                5. Exit
                """);
        }

        private static void PrintMenu()
        {
            Console.Clear();
            PrintLogo();
            Console.WriteLine("""
                1. User
                2. Account
                3. Transaction
                4. Exit
                """);
        }

        private static void PrintRed(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        private static int UserChoice(out int choice)
        {
            Console.Write("Your choice: ");
            if (int.TryParse(Console.ReadLine(), out choice))
                return choice;
            else return -1;
        }

        #region Create

        private static void CreateUser()
        {
            Console.Write("Please enter User name: ");
            string? userName = Console.ReadLine() ?? "";

            User user = new()
            {
                Name = userName
            };

            aTMContext.Users.Add(user);
        }

        private static void CreateAccount()
        {
            Console.Write("Please enter password: ");
            string password = Console.ReadLine() ?? string.Empty;
            
            Console.Write("Please enter balance: ");
            if(!decimal.TryParse(Console.ReadLine(), out decimal balance))
                balance = 0;
            
            Console.Write("Please enter card number: ");
            string cardNumber = Console.ReadLine() ?? string.Empty;

            Account account = new()
            {
                Password = password,
                Balance = balance,
                CardNumber = cardNumber,
                IsBlocked = false
            };

            aTMContext.Accounts.Add(account);
        }

        private static void CreateTransaction()
        {
            Console.Write("Please enter amount: ");
            if (!double.TryParse(Console.ReadLine(), out double amount))
                amount = 0;

            Console.Write("1. Withdraw\n2. Deposit\n");
            UserChoice(out int action);

            Transaction transaction = new()
            {
                TransactionTime = DateTime.Now,
                Amount = amount,
                TransactionAction = (Database.Models.Action)action
            };

            aTMContext.Transactions.Add(transaction);
        }

        private static void CreateSwitchCase(int createChoice)
        {
            bool stop = false;
            do
            {
                switch (createChoice)
                {
                    case 1:
                        CreateUser();
                        stop = true;
                        break;
                    case 2:
                        CreateAccount();
                        stop = true;
                        break;
                    case 3:
                        CreateTransaction();
                        stop = true;
                        break;
                    case 4:
                        Console.WriteLine("Bye");
                        Console.ReadKey(true);
                        stop = true;
                        break;
                    default:
                        PrintRed("Something went wrong");
                        break;
                }
            }while(!stop);

            aTMContext.SaveChanges();
        }

        #endregion

        #region Read

        private static void ReadUser()
        {
            Console.Write("Please enter User name: ");
            string? userName = Console.ReadLine() ?? "";

            var users = aTMContext.Users.Where(name => name.Name == userName).ToList();

            if (users.Count > 0)
            {
                foreach (var user in users)
                {
                    Console.WriteLine($"ID: {user.ID} | Name: {user.Name} | AccountID: {(user.AccountID == null ? "NULL" : user.AccountID)}");
                }
            } else { PrintRed("Empty List"); }

            Console.ReadKey(true);
        }

        private static void ReadAccount()
        {
            Console.Write("Please enter card number: ");
            string cardNumber = Console.ReadLine() ?? string.Empty;

            var accounts = aTMContext.Accounts.Where(cardNum => cardNum.CardNumber == cardNumber).ToList();

            if (accounts.Count > 0)
            {
                foreach (var acc in accounts)
                {
                    Console.WriteLine($"ID: {acc.ID} | Password: {acc.Password} | UserID: {(acc.UserID == null ? "NULL" : acc.UserID)} | Balance: {acc.Balance} | IsBlocked: {acc.IsBlocked}");
                }
            }
            else { PrintRed("Empty List"); }

            Console.ReadKey(true);
        }

        private static void ReadTransaction()
        {
            Console.Write("1. Withdraw\n2. Deposit\n");
            UserChoice(out int action);

            var transactions = aTMContext.Transactions.Where(trans => trans.TransactionAction == (Database.Models.Action)action).ToList();

            if (transactions.Count > 0)
            {
                foreach (var trans in transactions)
                {
                    Console.WriteLine($"ID: {trans.ID} | Time: {trans.TransactionTime} | Amount: {trans.Amount} | Action: {trans.TransactionAction}");
                }
            } else { PrintRed("Empty List"); }

            Console.ReadKey(true);
        }

        private static void ReadSwitchCase(int createChoice)
        {
            bool stop = false;
            do
            {
                switch (createChoice)
                {
                    case 1:
                        ReadUser();
                        stop = true;
                        break;
                    case 2:
                        ReadAccount();
                        stop = true;
                        break;
                    case 3:
                        ReadTransaction();
                        stop = true;
                        break;
                    case 4:
                        Console.WriteLine("Bye");
                        Console.ReadKey(true);
                        stop = true;
                        break;
                    default:
                        PrintRed("Something went wrong");
                        break;
                }
            } while (!stop);
        }

        #endregion

        #region Update

        private static void UpdateUser()
        {
            User usrToUpdate = new();
            Account accToUpdate = new();

            ReadUser();

            Console.Write("Please enter UserID: ");
            if(!int.TryParse(Console.ReadLine(), out int userID))
            {
                PrintRed("Can't update");
                return;
            }

            Console.Write("Please enter User name: ");
            string? userName = Console.ReadLine() ?? "";

            Console.Write("Please enter AccountID: ");
            if(!int.TryParse(Console.ReadLine(), out int accID))
            {
                PrintRed("Can't update");
                return;
            }
            else
            {
                usrToUpdate = aTMContext.Users.Where(usrID => usrID.ID == userID).First();
                usrToUpdate.AccountID = accID;

                accToUpdate = aTMContext.Accounts.Where(accNum => accNum.ID == accID).First();
                accToUpdate.UserID = usrToUpdate.ID;
            }

            aTMContext.Users.Update(usrToUpdate);
            aTMContext.Accounts.Update(accToUpdate);
        }

        private static void UpdateAccount()
        {
            User usrToUpdate = new();
            Account accToUpdate = new();

            ReadAccount();

            Console.Write("Please enter AccountID: ");
            if (!int.TryParse(Console.ReadLine(), out int accountID))
            {
                PrintRed("Can't update");
                return;
            }

            Console.Write("Please enter password: ");
            string password = Console.ReadLine() ?? string.Empty;

            Console.Write("Please enter balance: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal balance))
                balance = 0;

            Console.Write("Please enter card number: ");
            string cardNumber = Console.ReadLine() ?? string.Empty;

            Console.Write("1. Blocked\n2. Unblocked\n");
            UserChoice(out int blockStatus);
            bool status = false;
            status = blockStatus switch
            {
                1 => true,
                2 => false,
                _ => false,
            };
            Console.Write("Please enter UserID: ");
            if (!int.TryParse(Console.ReadLine(), out int usrID))
            {
                PrintRed("Can't update");
                return;
            }
            else
            {
                accToUpdate = aTMContext.Accounts.FirstOrDefault(accID => accID.ID == accountID);
                accToUpdate.UserID = usrID;
                accToUpdate.Balance = balance;
                accToUpdate.CardNumber = cardNumber;
                accToUpdate.Password = password;
                accToUpdate.IsBlocked = status;
            }
        }

        private static void UpdateTransaction()
        {
            Console.Write("Please enter amount: ");
            if (!double.TryParse(Console.ReadLine(), out double amount))
                amount = 0;

            Console.Write("1. Withdraw\n2. Deposit\n");
            UserChoice(out int action);

            Transaction transaction = new()
            {
                TransactionTime = DateTime.Now,
                Amount = amount,
                TransactionAction = (Database.Models.Action)action
            };

            aTMContext.Transactions.Add(transaction);
        }

        private static void UpdateSwitchCase(int createChoice)
        {
            bool stop = false;
            do
            {
                switch (createChoice)
                {
                    case 1:
                        UpdateUser();
                        stop = true;
                        break;
                    case 2:
                        UpdateAccount();
                        stop = true;
                        break;
                    case 3:
                        UpdateTransaction();
                        stop = true;
                        break;
                    case 4:
                        Console.WriteLine("Bye");
                        Console.ReadKey(true);
                        stop = true;
                        break;
                    default:
                        PrintRed("Something went wrong");
                        break;
                }
            } while (!stop);

            aTMContext.SaveChanges();
        }

        #endregion

        private enum PossibleChoice
        {
            Create = 1,
            Read = 2,
            Update = 3,
            Delete = 4,
            Exit = 5
        }
    }
}