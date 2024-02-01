using ExamAdvancedCSharp.Class;
using ExamAdvancedCSharp.Repos.Interfaces;

namespace ExamAdvancedCSharp.Repos
{
    internal class FoodItemRepository : IFoodItemRepository
    {
        #region ReadOnly

        private readonly string _pathToDrinks = @"D:\Projektai\Programavimas\CodeAcademy\Lesson50\Drinks.txt";
        private readonly string _pathToFood = @"D:\Projektai\Programavimas\CodeAcademy\Lesson50\Food.txt";
        private readonly Dictionary<string, List<FoodItem>> foodItems = [];

        #endregion

        public FoodItemRepository()
        {
            List<string> foodList = GetFoodItemList(_pathToFood);
            List<string> drinkList = GetFoodItemList(_pathToDrinks);

            LoadData(foodList, "Food");
            LoadData(drinkList, "Drinks");
        }

        public void AddFoodItem(string key, FoodItem foodItem)
        {
            if(!foodItems.ContainsKey(key))
            {
                foodItems.Add(key, [foodItem]);
            }
            else {foodItems[key].Add(foodItem);}
        }

        public Dictionary<string, List<FoodItem>> GetFoodItems() => foodItems;

        public void WriteFile(string key)
        {
            switch(key)
            {
                case "Drinks":
                    {
                        using StreamWriter streamWriter = new(_pathToDrinks);
                        for (int i = 0; i < foodItems[key].Count; i++)
                        {
                            streamWriter.WriteLine(foodItems[key][i]);
                        }
                    }
                    break;
                case "Food":
                    {
                        using StreamWriter streamWriter = new(_pathToFood);
                        for (int i = 0; i < foodItems[key].Count; i++)
                        {
                            streamWriter.WriteLine(foodItems[key][i]);
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

        private void LoadData(List<string> foodItemsList, string key)
        {
            for(int i = 0; i < foodItemsList.Count; i += 2)
            {
                FoodItem foodItem = new(foodItemsList[i], Convert.ToDouble(foodItemsList[i + 1]));
                AddFoodItem(key, foodItem);
            }
        }
    }
}