using ExamAdvancedCSharp.Class;

namespace ExamAdvancedCSharp.Repos.Interfaces
{
    internal interface IFoodItemRepository
    {
        public void AddFoodItem(FoodItem foodItem);

        public void WriteFile(FoodType key);

        public List<FoodItem> GetFoodItems();
    }
}
