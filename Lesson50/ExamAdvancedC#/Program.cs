using ExamAdvancedCSharp.Service;
using ExamAdvancedCSharp.Class;
using ExamAdvancedCSharp.Service.Interfaces;

namespace ExamAdvancedCSharp
{
    internal class Program
    {
        private static readonly IFoodItemService _foodItemService = new FoodItemService();

        static void Main()
        {
            bool stopProgram = false;

            do
            {
                Console.Clear();
                PrintLogo();
                PrintMenu();
                PrintAskForChoice();

                int choice = GetChoice();

                switch (choice)
                {
                    case 1: // Start Order
                        break;
                    case 2: // Display All Tables
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
            }while (!stopProgram);
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

        #endregion

        #region Get Function

        private static int GetChoice()
        {
            if (int.TryParse(Console.ReadLine(), out int choice))
                return choice;
            return 0;
        }

        #endregion

        private static void AddFood()
        {
            Console.Write("Please write food name: ");
            string? name = Console.ReadLine();
            Console.Write($"Please write price of {name}: ");
            double price = 0;
            if (name != null)
            {
                price = double.Parse(Console.ReadLine()!);

                _foodItemService.AddFoodItem("Food", name, price);

                _foodItemService.WriteFile("Food");
            }
            else
            {
                Console.WriteLine("Something went wrong");
                Console.ReadKey(true);
            }

            Console.WriteLine($"{name} -- {price:0.##} has been added");
            Console.ReadKey(true);
        }

        private static void AddDrinks()
        {
            Console.Write("Please write drink name: ");
            string? name = Console.ReadLine();
            Console.Write($"Please write price of {name}: ");
            double price = 0;
            if (name != null)
            {
                price = double.Parse(Console.ReadLine()!);

                _foodItemService.AddFoodItem("Drinks", name, price);

                _foodItemService.WriteFile("Drinks");
            }
            else
            {
                Console.WriteLine("Something went wrong");
                Console.ReadKey(true);
            }

            Console.WriteLine($"{name} -- {price:0.##} has been added");
            Console.ReadKey(true);
        }
    }
}