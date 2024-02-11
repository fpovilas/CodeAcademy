using ExamAdvancedCSharp.Class;
using ExamAdvancedCSharp.Repos.Interfaces;
using System.Text;

namespace ExamAdvancedCSharp.Repos
{
    internal class OrderRepository : IOrderRepository
    {
        private readonly string _pathToOrdersDB = @"D:\Projektai\Programavimas\CodeAcademy\Lesson50\ExamAdvancedC#\DB\Orders\";
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

        public string SaveReceipt(int orderID)
        {
            Order? order = orders.FirstOrDefault(id => id.GetID() == orderID);
            if (order == null)
                { return "Order could not be saved."; }
            else
            {
                string orderTime = order.GetOrderTime().ToString("y/MM/dd-HH.mm");
                string pathToReceipt = _pathToOrdersDB + $"{orderTime}_{orderID:000000}_{order.GetTable().GetTableName()}.txt";
                using StreamWriter streamWriter = new(pathToReceipt);
                streamWriter.Write(BuildReceipt(order));
                streamWriter.Close();

                return $"Oder {orderID:000000} has been saved in database";
            }
        }

        private static string BuildReceipt(Order order)
        {
            List<FoodItem> foodItems = order.GetFoodItems();
            Dictionary<string, int> distinctFood = order.GetFoodItems().GroupBy(n => n.GetName())
                                                                       .ToDictionary(x => x.Key, x => x.Count());
            Table table = order.GetTable();
            Waiter waiter = table.GetWaiter()!;

            StringBuilder receiptBuilder = new();
            receiptBuilder.AppendLine($"Order: {order.GetID(),6:000000} Order Time: {order.GetOrderTime()}\n");

            double totalAmount = 0;
            foreach(KeyValuePair<string, int> kvp in distinctFood)
            {
                double price = foodItems.FirstOrDefault(x => x.GetName().Equals(kvp.Key))!
                                        .GetPrice();

                receiptBuilder.AppendLine($"{kvp.Key, -20} {price,6:##0.00} x {kvp.Value,2} - {price * kvp.Value,6:##0.00}€");

                totalAmount += price * kvp.Value;
            }

            receiptBuilder.AppendLine($"{"Total paid amount with VAT:", -35} {totalAmount,6:##0.00}€");
            receiptBuilder.AppendLine($"{"Total paid amount w\\o VAT(21%):", -35} {(totalAmount * 0.79),6:##0.00}€");
            receiptBuilder.AppendLine($"\nTable: {table.GetTableName()} Served by: {waiter.GetName()}");

            return receiptBuilder.ToString();
        }
    }
}