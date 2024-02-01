using ExamAdvancedCSharp.Class;

namespace ExamAdvancedCSharp.Service.Interfaces
{
    internal interface IFoodItemService
    {
        public void AddFoodItem(string key, string name, double price);

        public void AddFoodItem(string key, FoodItem foodItem);

        public void WriteFile(string key);

        public Dictionary<string, List<FoodItem>> GetFoodItems();
    }
}
