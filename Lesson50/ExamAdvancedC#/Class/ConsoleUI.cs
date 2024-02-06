using ExamAdvancedCSharp.Service.Interfaces;

namespace ExamAdvancedCSharp.Class
{
    internal class ConsoleUI(IFoodItemService foodItemService, IOrderService orderService, ITableService tableService)
    {
        private readonly IFoodItemService _foodItemService = foodItemService;
        private readonly IOrderService _orderService = orderService;
        private readonly ITableService _tableService = tableService;

        public void Run()
        {

            bool stopProgram = false;

            do
            {
                ClearAndPrintLogo();
                PrintMenu();

                int choice = GetChoice();

                switch (choice)
                {
                    case 1: // Start Order
                        Console.Write("Please enter your name: ");
                        string? waiterName = Console.ReadLine();
                        if (waiterName == string.Empty || waiterName == null)
                        {
                            Console.WriteLine("Something went wrong.");
                            Console.ReadKey(true);
                            continue;
                        }
                        else
                        {
                            ClearAndPrintLogo();
                            PrintTables();
                            int tableChoiceForOrder = GetChoice();
                            Waitress waitress = new(waiterName);
                            Table chosenTable = _tableService.GetTables()[tableChoiceForOrder - 1];

                            chosenTable.SetWaitress(waitress);

                            ClearAndPrintLogo();
                            Console.WriteLine($"Hello, {waiterName}. Ordering for {chosenTable.GetTableName()}");

                            bool stop = false;
                            do
                            {
                                List<FoodItem> list = [];
                                int index = 1;
                                foreach (var foodItem in _foodItemService.GetFoodItems())
                                {
                                    if (foodItem.GetFoodType() == FoodType.Food)
                                    {
                                        Console.WriteLine($"{index++,2}. {foodItem.GetName(),-16} --- {foodItem.GetPrice(),6:##0.00}€");
                                        list.Add(foodItem);
                                    }
                                }
                                foreach (var foodItem in _foodItemService.GetFoodItems())
                                {
                                    if (foodItem.GetFoodType() == FoodType.Drinks)
                                    {
                                        Console.WriteLine($"{index++,2}. {foodItem.GetName(),-16} --- {foodItem.GetPrice(),6:##0.00}€");
                                        list.Add(foodItem);
                                    }
                                }

                                int chosenFoodIem = GetChoice();
                                // Need to get last order ID and add one to it if empty start with 0
                                if(_orderService.GetOrders().Count != 0)
                                {
                                    _orderService.GetOrders().Last().GetID();
                                }

                                Console.ReadKey(true);
                            } while (!stop);
                        }
                        // Ask for Waitress/Waiter name
                        // Select table
                        // Create waiter object
                        // Make relationship between table and waiter
                        // Give menu to choose food
                        // Create food list
                        // Print sorted completed list
                        // Ask to confirm that everything okay
                        // If okay add this order to table
                        // If not give to choose products again after that go to confirmation
                        break;
                    case 2: // Display All Tables and do actions with them
                        ClearAndPrintLogo();
                        PrintTables();

                        int tableChoice = GetChoice();

                        DoWhileTableAction(tableChoice);
                        break;
                    case 3: // Adding Food
                        AddFood();
                        break;
                    case 4: // Adding Drinks
                        AddDrinks();
                        break;
                    case 5: // Stopping program
                        stopProgram = true;
                        break;
                    default:
                        Console.WriteLine($"Wrong Choice ({choice})");
                        Console.ReadKey(true);
                        break;
                }
            } while (!stopProgram);
        }

        #region Print Functions

        private static void PrintLogo()
        {
            Console.WriteLine("""
                    ____  _       _                  
                   / __ \(_)___  (_)___  ____ _      
                  / / / / / __ \/ / __ \/ __ `/      
                 / /_/ / / / / / / / / / /_/ /       
                /_____/_/_/ /_/_/_/ /_/\__, /        
                    ____             _/____/         
                   / __ \___  ____ _/ ___/__  _______
                  / /_/ / _ \/ __ `/\__ \/ / / / ___/
                 / _, _/  __/ /_/ /___/ / /_/ (__  ) 
                /_/ |_|\___/\__, //____/\__, /____/  
                           /____/      /____/     

                """);
        }

        private static void PrintMenu()
        {
            Console.WriteLine("""
                1. Start Order
                2. All Tables
                3. Add Food
                4. Add Drink
                5. Exit
                """);
        }

        private static void PrintAskForChoice()
        {
            Console.Write("Your choice: ");
        }

        private static void PrintMenuForTableAction()
        {
            Console.WriteLine("""
                1. Pay bill
                2. Reserve table
                3. Vacate table
                4. Exit
                """);
        }

        private static void ClearAndPrintLogo()
        {
            Console.Clear();
            PrintLogo();
        }

        private void PrintTables()
        {
            int index = 1;
            foreach (var table in _tableService.GetTables())
            {
                Console.WriteLine($"{index++}. {table}");
            }
        }

        #endregion

        #region Get Function

        private static int GetChoice()
        {
            PrintAskForChoice();
            if (int.TryParse(Console.ReadLine(), out int choice))
                return choice;
            return 0;
        }

        #endregion

        private void AddFood()
        {
            Console.Write("Please write food name: ");
            string? name = Console.ReadLine();
            Console.Write($"Please write price of {name}: ");
            double price = 0;
            if (name != null)
            {
                price = double.Parse(Console.ReadLine()!);

                _foodItemService.AddFoodItem(name, price, FoodType.Food);

                _foodItemService.WriteFile(FoodType.Food);
            }
            else
            {
                Console.WriteLine("Something went wrong");
                Console.ReadKey(true);
            }

            Console.WriteLine($"{name} -- {price:##0.##} has been added");
            Console.ReadKey(true);
        }

        private void AddDrinks()
        {
            Console.Write("Please write drink name: ");
            string? name = Console.ReadLine();
            Console.Write($"Please write price of {name}: ");
            double price = 0;
            if (name != null)
            {
                price = double.Parse(Console.ReadLine()!);

                _foodItemService.AddFoodItem(name, price, FoodType.Drinks);

                _foodItemService.WriteFile(FoodType.Drinks);
            }
            else
            {
                Console.WriteLine("Something went wrong");
                Console.ReadKey(true);
            }

            Console.WriteLine($"{name} -- {price:##0.##} has been added");
            Console.ReadKey(true);
        }

        private void DoWhileTableAction(int tableChoice)
        {
            bool exit = true;
            do
            {
                Table table = _tableService.GetTables()[tableChoice - 1];
                string tableName = table.GetTableName();
                string tableState = $"{(table.GetTableState() ? "Unavailable" : "Available")}";
                ClearAndPrintLogo();
                Console.WriteLine($"You chose {tableName} and it is {tableState}");
                PrintMenuForTableAction();
                int tableActionChoice = GetChoice();
                switch (tableActionChoice)
                {
                    case 1: // Pay Bill
                        break;
                    case 2: // Reserve Table
                        table.SetTableSate(true);
                        Console.WriteLine("Table reserved.");
                        Console.ReadKey(true);
                        break;
                    case 3: // Vacate Table (Checking if table bills is paid needed)
                        table.SetTableSate(false);
                        Console.WriteLine("Table vacated.");
                        Console.ReadKey(true);
                        break;
                    case 4:
                        Console.WriteLine("Exiting.");
                        Console.ReadKey();
                        exit = false;
                        break;
                    default:
                        Console.WriteLine("Something went wrong.");
                        Console.ReadKey();
                        continue;
                }
            } while (exit);
        }
    }
}