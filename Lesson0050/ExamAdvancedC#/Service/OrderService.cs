using ExamAdvancedCSharp.Class;
using ExamAdvancedCSharp.Repos.Interfaces;
using ExamAdvancedCSharp.Service.Interfaces;

namespace ExamAdvancedCSharp.Service
{
    internal class OrderService(IOrderRepository orderRepository) : IOrderService
    {
        private readonly IOrderRepository _orderRepository = orderRepository;

        public void AddOrder(Order order) => _orderRepository.AddOrder(order);

        public List<Order> GetOrders() => _orderRepository.GetOrders();

        public string SaveReceipt(int orderID) => _orderRepository.SaveReceipt(orderID);
    }
}
