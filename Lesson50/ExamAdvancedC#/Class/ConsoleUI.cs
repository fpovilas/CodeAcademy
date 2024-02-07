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
                    // Start Order
                    case 1:
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
                            int tableChoiceForNewOrder = GetTable();

                            if (tableChoiceForNewOrder == 0)
                                continue;

                            Waiter waiter = new(waiterName);
                            Table chosenTable = _tableService.GetTables()[tableChoiceForNewOrder - 1];

                            chosenTable.SetWaiter(waiter);

                            ClearAndPrintLogo();
                            Console.WriteLine($"Hello, {waiterName}. Ordering for {chosenTable.GetTableName()}");
                            chosenTable.SetTableSate(true);

                            int newOrderID = GetOrderID();
                            Order newOrder = new(newOrderID, chosenTable);
                            StartOrdering(newOrder);
                            PrintOrder(newOrder);
                            _orderService.AddOrder(newOrder);
                            PrintTextInGreen("Press any button to continue.");
                            Console.ReadKey(true);
                        }
                        break;
                    // Display All Tables and do actions with them
                    case 2:
                        ClearAndPrintLogo();
                        PrintTables();

                        int tableChoice = GetChoice();

                        TableAction(tableChoice);
                        break;
                    // Adding Food
                    case 3:
                        AddFood();
                        break;
                    // Adding Drinks
                    case 4:
                        AddDrinks();
                        break;
                    // Stopping program
                    case 5:
                        stopProgram = true;
                        break;
                    default:
                        PrintTextInRead($"Wrong choice ({choice})");
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

        private static void PrintAskForChoice(bool withExit)
        {
            if(withExit)
                Console.Write("Your choice. To exit type \"q\": ");
            else
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

        private static void PrintOrder(Order newOrder)
        {
            ClearAndPrintLogo();
            Console.WriteLine("Your order:");
            foreach (FoodItem food in newOrder.GetFoodItems())
            {
                Console.WriteLine($"{food.GetName(),-16} - {food.GetPrice(),6:##0.00}€");
            }
        }

        private static void PrintTextInRead(string text)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        private static void PrintTextInGreen(string text)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        #endregion

        #region Get Function

        private static int GetChoice(bool withExit = false)
        {
            PrintAskForChoice(withExit);
            if (int.TryParse(Console.ReadLine(), out int choice))
                return choice;
            return 0;
        }

        private int GetTable()
        {
            int tableChoiceForNewOrder;
            bool freeTableChosen = false;
            do
            {
                ClearAndPrintLogo();
                PrintTables();
                tableChoiceForNewOrder = GetChoice(true);
                if (_tableService.GetTables().Count >= tableChoiceForNewOrder && tableChoiceForNewOrder != 0)
                {
                    if (_tableService.GetTables()[tableChoiceForNewOrder - 1].GetTableState())
                    {
                        PrintTextInRead($"{_tableService.GetTables()[tableChoiceForNewOrder - 1].GetTableName()} is already taken");
                        Console.ReadKey(true);
                        continue;
                    }
                    else
                    {
                        freeTableChosen = true;
                    }
                }
                else if (tableChoiceForNewOrder == 0) { break; }

            } while (!freeTableChosen);

            return tableChoiceForNewOrder;
        }

        private int GetOrderID()
        {
            int newOrderID = 1;
            if (_orderService.GetOrders().Count != 0)
            {
                newOrderID = _orderService.GetOrders().Last().GetID() + 1;
            }

            return newOrderID;
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

        private void TableAction(int tableChoice)
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

                List<Order> orderList = _orderService.GetOrders()
                                     .Where(
                                        tbl => tbl.GetIsPaid() == false &&
                                               tbl.GetTable().GetTableName() == table.GetTableName())
                                     .ToList();

                switch (tableActionChoice)
                {
                    // Pay Bill
                    case 1:
                        if(orderList.Count == 1 )
                        {
                            Order order = orderList[0];
                            Dictionary<string, int> distinctFood = order.GetFoodItems().GroupBy(n => n.GetName())
                                                                                       .ToDictionary(x => x.Key, x => x.Count());
                            Console.WriteLine($"""
                                ########################################
                                # ----------------   ----------------- #
                                # Order ID {order.GetID():000000}  {order.GetOrderTime()} #
                                """);
                            double total = 0;
                            foreach(KeyValuePair<string, int> foodItem in distinctFood)
                            {
                                double price = _foodItemService.GetFoodItems()
                                                               .FirstOrDefault(x => x.GetName().Equals(foodItem.Key))!
                                                               .GetPrice();
                                Console.WriteLine($"# {foodItem.Key, -16} x {foodItem.Value, -2} ---{"",4}{price * foodItem.Value, 6:##0.00}€ #");
                                total += price * foodItem.Value;
                            }
                            Console.WriteLine($"""
                                # ----------------   ----------------- #
                                # Total: {total, 6:##0.00}€{"", 22} #
                                ########################################
                                """);
                        }
                        else { PrintTextInRead("Something went wrong"); }
                        Console.ReadKey(true);
                        break;
                    // Reserve Table
                    case 2:
                        if (table.GetTableState())
                        {
                            PrintTextInRead("Table already in use.");
                            Console.ReadKey(true);
                        }
                        else
                        {
                            table.SetTableSate(true);
                            PrintTextInGreen($"{table.GetTableName()} reserved.");
                            Console.ReadKey(true);
                        }
                        break;
                    // Vacate Table (Checking if table bills is paid needed)
                    case 3:
                        if (orderList.Count > 0)
                        {
                            PrintTextInRead($"You cannot vacate {table.GetTableName()} because it has unpaid bills");
                            Console.ReadKey(true);
                        }
                        else
                        {
                            table.SetTableSate(false);
                            PrintTextInGreen("Table vacated.");
                            Console.ReadKey(true);
                        }
                        break;
                    // Exit
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

        private void StartOrdering(Order newOrder)
        {
            bool stopOrder = false;
            do
            {
                int chosenFoodItem;
                bool stopChoosingFoodItem = false;
                do
                {
                    ClearAndPrintLogo();
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
                    chosenFoodItem = GetChoice();
                    if (chosenFoodItem < list.Count && chosenFoodItem != 0)
                    {
                        newOrder.AddFoodItem(list[chosenFoodItem - 1]);
                        Console.WriteLine($"{list[chosenFoodItem - 1].GetName()} - {list[chosenFoodItem - 1].GetPrice()}€ has been added");
                        stopChoosingFoodItem = true;
                    }
                    else
                    {
                        PrintTextInRead("Something went wrong please try again.");
                        Console.ReadKey(true);
                        continue;
                    }
                } while(!stopChoosingFoodItem);

                bool stopQuestion = false;
                while (!stopQuestion)
                {
                    Console.Write("Do you want to stop ordering?(y/n) ");
                    string? stopOrdering = Console.ReadLine();
                    if (stopOrdering != null)
                    {
                        if (stopOrdering.ToLower().Equals("y"))
                        {
                            stopOrder = true;
                            stopQuestion = true;
                        }
                        else if (stopOrdering.ToLower().Equals("n"))
                            stopQuestion = true;
                        else
                            continue;
                    }
                }
            } while (!stopOrder);
        }
    }
}