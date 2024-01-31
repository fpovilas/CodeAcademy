using ExamAdvancedCSharp.Class;

namespace ExamAdvancedCSharp.Repos
{
    internal class DrinkItemRepository
    {
        private readonly List<DrinkItem> drinkItems = [];

        public void AddDrinkItem(DrinkItem drinkItem) => drinkItems.Add(drinkItem);

        public List<DrinkItem> GetDrinkItems() => drinkItems;
    }
}
