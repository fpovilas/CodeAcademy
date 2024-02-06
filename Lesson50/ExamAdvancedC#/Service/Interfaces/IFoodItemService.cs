using ExamAdvancedCSharp.Class;

namespace ExamAdvancedCSharp.Service.Interfaces
{
    internal interface IFoodItemService
    {
        public void AddFoodItem(string name, double price, FoodType foodType);

        public void AddFoodItem(FoodItem foodItem);

        public void WriteFile(FoodType key);

        public List<FoodItem> GetFoodItems();
    }
}
