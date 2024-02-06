using ExamAdvancedCSharp.Class;

namespace ExamAdvancedCSharp.Repos.Interfaces
{
    internal interface IOrderRepository
    {
        public void AddOrder(Order order);

        public List<Order> GetOrders();
    }
}
