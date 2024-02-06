using ExamAdvancedCSharp.Class;
using ExamAdvancedCSharp.Repos.Interfaces;
using ExamAdvancedCSharp.Service.Interfaces;

namespace ExamAdvancedCSharp.Service
{
    internal class FoodItemService(IFoodItemRepository foodItemRepository) : IFoodItemService
    {
        private readonly IFoodItemRepository _repository = foodItemRepository;

        public void AddFoodItem(string name, double price, FoodType foodType)
        {
            FoodItem foodItem = new(name, price, foodType);
            _repository.AddFoodItem(foodItem);
        }

        public void AddFoodItem(FoodItem foodItem)
        {
            _repository.AddFoodItem(foodItem);
        }

        public void WriteFile(FoodType key) => _repository.WriteFile(key);

        public List<FoodItem> GetFoodItems()
            => _repository.GetFoodItems();
    }
}
