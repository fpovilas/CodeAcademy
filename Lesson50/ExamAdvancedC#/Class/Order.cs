namespace ExamAdvancedCSharp.Class
{
    internal class Order(int id, Table table)
    {
        private int ID { get; set; } = id;
        private DateTime OrderTime { get; set; } = DateTime.Now;
        private List<FoodItem> FoodItems { get; set; } = [];
        private bool IsPaid { get; set; } = false;
        private Table Table { get; set; } = table;

        public int GetID() => ID;
        public string GetOrderTime() => OrderTime.ToString();
        public List<FoodItem> GetFoodItems() => FoodItems;
        public bool GetIsPaid() => IsPaid;
        public Table GetTable() => Table;

        public void SetIsPaid(bool state) => IsPaid = state;
        public void AddFoodItem(FoodItem foodItem) => FoodItems.Add(foodItem);
    }
}
