using ExamAdvancedCSharp.Repos;
using ExamAdvancedCSharp.Service;
using ExamAdvancedCSharp.Class;

namespace ExamAdvancedCSharp
{
    internal class Program
    {
        static void Main()
        {
            bool stopProgram = false;
            FoodItemService foodItemService = new(new FoodItemRepository());
            ReadFileService readFileService = new(@"D:\Projektai\Programavimas\CodeAcademy\Lesson50\", "Food.txt");
            var list = readFileService.ReadFile<FoodItem>();

            foreach(var item in list)
            {
                foodItemService.AddFoodItem(item);
            }

            do
            {
                Console.Clear();
                PrintLogo();
                PrintMenu();
                PrintAskForChoice();

                int choice = GetChoice();

                switch (choice)
                {
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
                        WriteFileService writeFileService = new("D:\\Projektai\\Programavimas\\CodeAcademy\\Lesson50\\", "Food.txt");
                        string? name = Console.ReadLine();
                        double price = double.Parse(Console.ReadLine());

                        foodItemService.AddFoodItem(name, price);

                        writeFileService.WriteFile(foodItemService.GetFoodItems());
                        break;
                    case 4:
                        break;
                    case 5:
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
    }
}