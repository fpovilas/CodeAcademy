namespace ExamAdvancedCSharp.Class
{
    internal class FoodItem(string name, double price, FoodType foodType)
    {
        private string Name { get; set; } = name;
        private double Price { get; set; } = price;
        private FoodType FoodType { get; set; } = foodType;

        public string GetName() => Name;
        public double GetPrice() => Price;
        public FoodType GetFoodType() => FoodType;

        public override string ToString() => $"{Name};{Price}";
    }

    enum FoodType
    {
        Drinks = 3,
        Food = 4
    }
}