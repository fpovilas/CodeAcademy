namespace ExamAdvancedCSharp.Class
{
    internal class Order
    {
        private int ID { get; set; }
        private DateTime OrderTime { get; set; } = DateTime.Now;
        private List<FoodItem> FoodItems { get; set; } = [];
        private bool IsPaid { get; set; } = false;

        public int GetID() => ID;
        public string GetOrderTime() => OrderTime.ToString();
        public List<FoodItem> GetFoodItems() => FoodItems;
        public bool GetIsPaid() => IsPaid;

        public void SetIsPaid(bool state) => IsPaid = state;
    }
}
