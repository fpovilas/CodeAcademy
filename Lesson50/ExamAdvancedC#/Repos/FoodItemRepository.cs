using ExamAdvancedCSharp.Class;

namespace ExamAdvancedCSharp.Repos
{
    internal class FoodItemRepository
    {
        private readonly List<FoodItem> foodItems = [];

        public void AddFoodItem(FoodItem foodItem) => foodItems.Add(foodItem);

        public List<FoodItem> GetFoodItems() => foodItems;
    }
}
