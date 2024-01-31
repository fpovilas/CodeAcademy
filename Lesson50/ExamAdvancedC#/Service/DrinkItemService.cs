using ExamAdvancedCSharp.Repos;
using ExamAdvancedCSharp.Class;

namespace ExamAdvancedCSharp.Service
{
    internal class DrinkItemService(DrinkItemRepository repo)
    {
        private readonly DrinkItemRepository repository = repo;

        public void AddDrinkItem(string name, double price)
        {
            DrinkItem drinkItem = new(name, price);
            repository.AddDrinkItem(drinkItem);
        }

        public void AddDrinkItem(DrinkItem drinkItem)
        {
            repository.AddDrinkItem(drinkItem);
        }

        public List<DrinkItem> GetDrinkItems()
            => repository.GetDrinkItems();
    }
}
