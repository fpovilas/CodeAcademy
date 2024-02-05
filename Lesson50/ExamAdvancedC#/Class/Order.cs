namespace ExamAdvancedCSharp.Class
{
    internal class Order
    {
        private DateTime OrderTime { get; set; } = DateTime.Now;
        private List<FoodItem> FoodItems { get; set; } = [];

        public string GetOrderTime() => OrderTime.ToString();
        public List<FoodItem> GetFoodItems() => FoodItems;
    }
}
