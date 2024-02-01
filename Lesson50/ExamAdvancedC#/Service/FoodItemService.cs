using ExamAdvancedCSharp.Class;
using ExamAdvancedCSharp.Repos;
using ExamAdvancedCSharp.Service.Interfaces;

namespace ExamAdvancedCSharp.Service
{
    internal class FoodItemService() : IFoodItemService
    {
        private readonly FoodItemRepository repository = new();

        public void AddFoodItem(string key, string name, double price)
        {
            FoodItem foodItem = new(name, price);
            repository.AddFoodItem(key, foodItem);
        }

        public void AddFoodItem(string key, FoodItem foodItem)
        {
            repository.AddFoodItem(key, foodItem);
        }

        public void WriteFile(string key) => repository.WriteFile(key);

        public Dictionary<string, List<FoodItem>> GetFoodItems()
            => repository.GetFoodItems();
    }
}
