using ExamAdvancedCSharp.Class;
using ExamAdvancedCSharp.Repos.Interfaces;

namespace ExamAdvancedCSharp.Repos
{
    internal class FoodItemRepository : IFoodItemRepository
    {
        #region ReadOnly

        private readonly string _pathToDrinks = @"D:\Projektai\Programavimas\CodeAcademy\Lesson50\ExamAdvancedC#\DB\Drinks.txt";
        private readonly string _pathToFood = @"D:\Projektai\Programavimas\CodeAcademy\Lesson50\ExamAdvancedC#\DB\Food.txt";
        private readonly List<FoodItem> foodItems = [];

        #endregion

        public FoodItemRepository()
        {
            List<string> foodList = GetFoodItemList(_pathToFood);
            List<string> drinkList = GetFoodItemList(_pathToDrinks);

            LoadData(foodList, FoodType.Food);
            LoadData(drinkList, FoodType.Drinks);
        }

        public void AddFoodItem(FoodItem foodItem) => foodItems.Add(foodItem);

        public List<FoodItem> GetFoodItems() => foodItems;

        public void WriteFile(FoodType key)
        {
            switch(key)
            {
                case FoodType.Drinks:
                    {
                        using StreamWriter streamWriter = new(_pathToDrinks);
                        for (int i = 0; i < foodItems.Count; i++)
                        {
                            if (foodItems[i].GetFoodType() == FoodType.Drinks)
                                streamWriter.WriteLine(foodItems[i]);
                        }
                    }
                    break;
                case FoodType.Food:
                    {
                        using StreamWriter streamWriter = new(_pathToFood);
                        for (int i = 0; i < foodItems.Count; i++)
                        {
                            if (foodItems[i].GetFoodType() == FoodType.Food)
                                streamWriter.WriteLine(foodItems[i]);
                        }
                    }
                    break;
                default:
                    Console.WriteLine($"Something went wrong ({key})");
                    Console.ReadKey(true);
                    break;
            }
        }

        private static List<string> GetFoodItemList(string path)
        {
            List<string> foodItemList = File.ReadAllText(path)
                            .Replace("\r\n", ";")
                            .Split(";")
                            .Where(itm => itm != string.Empty)
                            .ToList();

            return foodItemList;
        }

        private void LoadData(List<string> foodItemsList, FoodType foodType)
        {
            for(int i = 0; i < foodItemsList.Count; i += 2)
            {
                FoodItem foodItem = new(foodItemsList[i], Convert.ToDouble(foodItemsList[i + 1]), foodType);
                AddFoodItem(foodItem);
            }
        }
    }
}