using Task4.Class;

namespace Task4
{
    internal class Program
    {
        static void Main()
        {
            PrintMenu();
            int choice = GetChoice();

            SwitchCase(choice);
        }

        private static void PrintMenu()
        {
            Console.WriteLine("""
                1. Example with Car and Engine Class
                2. Example with Person and Address Class
                3. Example with Bank and Account Class
                """);
        }

        private static int GetChoice()
        {
            Console.WriteLine("Please enter your choice");
            if (int.TryParse(Console.ReadLine(), out var choice))
            {
                return choice;
            }
            return 0;
        }

        private static void PrintEngineState(Car car)
        {
            Console.WriteLine($"The engine of car {car.Name} is {car.GetEngineState()}");
        }

        private static void CreateBankAccount(Bank bank, string owner, double balance)
        {
            bank.CreateAccount(owner, balance);
        }

        private static void SwitchCase(int choice)
        {
            switch (choice)
            {
                case 1:
                    Car car = new("Kia");
                    car.SetEngineState(false);

                    PrintEngineState(car);
                    break;
                case 2:
                    Person person = new("Povilas", 26);
                    person.SetAddress("Šiauliai", "Dubijos 25 st.");

                    Console.WriteLine(person.GetInformation());
                    break;
                case 3:
                    Bank bank = new("Swed");
                    CreateBankAccount(bank, "Povilas", 666.66);

                    Console.WriteLine($"{bank.Name}:");
                    foreach(Account account in bank.Account)
                    {
                        Console.WriteLine($"\t- {account.Owner} Balance: {account.Balance}€");
                    }

                    Console.Write("How much to add to balance: ");
                    double addBalance = double.Parse(Console.ReadLine() ?? "0");

                    foreach (Account account in bank.Account)
                    {
                        if(account.Owner == "Povilas")
                            account.ChangeBalance(account.Balance + addBalance);
                        Console.WriteLine($"\t- {account.Owner} Balance: {account.Balance}€");
                    }
                    break;
                default:
                    Console.WriteLine("Wrong choice...");
                    break;
            }
        }
    }
}