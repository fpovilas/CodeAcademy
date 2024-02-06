using ExamAdvancedCSharp.Class;
using ExamAdvancedCSharp.Repos.Interfaces;
using System.Linq;

namespace ExamAdvancedCSharp.Repos
{
    internal class OrderRepository : IOrderRepository
    {
        private readonly List<Order> orders = [];

        public List<Order> GetOrders() => orders;

        public void AddOrder(Order order)
        {
            if(!orders.Any(id => id.GetID() == order.GetID()))
            {
                orders.Add(order);
            }
            else { Console.WriteLine("Order with same ID already exists"); }
        }
    }
}
