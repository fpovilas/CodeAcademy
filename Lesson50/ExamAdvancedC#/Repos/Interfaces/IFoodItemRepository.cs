using ExamAdvancedCSharp.Class;

namespace ExamAdvancedCSharp.Repos.Interfaces
{
    internal interface IFoodItemRepository
    {
        public void AddFoodItem(string key, FoodItem foodItem);

        public void WriteFile(string key);

        public Dictionary<string, List<FoodItem>> GetFoodItems();
    }
}
