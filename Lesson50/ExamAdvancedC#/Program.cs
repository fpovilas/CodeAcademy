using ExamAdvancedCSharp.Class;
using ExamAdvancedCSharp.Repos;
using ExamAdvancedCSharp.Repos.Interfaces;
using ExamAdvancedCSharp.Service;
using ExamAdvancedCSharp.Service.Interfaces;

namespace ExamAdvancedCSharp
{
    internal class Program
    {
        static void Main()
        {
            // Initialize repos and services and pass it to ConsoleUI
            // Repo to Service and Service to ConsoleUI

            IFoodItemRepository foodItemRepository = new FoodItemRepository();
            IFoodItemService foodItemService = new FoodItemService(foodItemRepository);

            IOrderRepository orderRepository = new OrderRepository();
            IOrderService orderService = new OrderService(orderRepository);

            ITableRepository tableRepository = new TableRepository();
            ITableService tableService = new TableService(tableRepository);

            ConsoleUI ui = new(foodItemService, orderService, tableService);

            ui.Run();
        }
    }
}