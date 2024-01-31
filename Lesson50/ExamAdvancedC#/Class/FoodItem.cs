namespace ExamAdvancedCSharp.Class
{
    internal class FoodItem(string name, double price)
    {
        private string Name { get; set; } = name;
        private double Price { get; set; } = price;

        public string GetName() => Name;
        public double GetPrice() => Price;

        public override string ToString() => $"{Name,-12} -- {Price,-6}€";
        public string ToStringToFile() => $"{Name};{Price}";
    }
}