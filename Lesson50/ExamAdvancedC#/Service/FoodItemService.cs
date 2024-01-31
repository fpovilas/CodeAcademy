using ExamAdvancedCSharp.Class;
using ExamAdvancedCSharp.Repos;

namespace ExamAdvancedCSharp.Service
{
    internal class FoodItemService(FoodItemRepository repo)
    {
        private readonly FoodItemRepository repository = repo;

        public void AddFoodItem(string name, double price)
        {
            FoodItem foodItem = new(name, price);
            repository.AddFoodItem(foodItem);
        }

        public void AddFoodItem(FoodItem foodItem)
        {
            repository.AddFoodItem(foodItem);
        }

        public List<FoodItem> GetFoodItems()
            => repository.GetFoodItems();
    }
}
