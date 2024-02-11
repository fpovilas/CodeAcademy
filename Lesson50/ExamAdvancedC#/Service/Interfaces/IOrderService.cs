using ExamAdvancedCSharp.Class;

namespace ExamAdvancedCSharp.Service.Interfaces
{
    internal interface IOrderService
    {
        public void AddOrder(Order order);
        public List<Order> GetOrders();
        public string SaveReceipt(int orderID);
    }
}
