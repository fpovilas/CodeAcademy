using Task2.Class;

namespace Task2
{
    internal class Program
    {
        static void Main()
        {
            PrintMenu();
            int choice = GetChoice();

            SwitchCase(choice);

        }

        private static void PrintMenu()
        {
            Console.WriteLine("""
                1. Example with Food and Product class
                2. Extended Product class with Electronic classq
                3. Not Yet Done
                """);
        }

        private static int GetChoice()
        {
            Console.Write("Please enter your choice: ");
            if (int.TryParse(Console.ReadLine(), out int choice)) { return choice; }
            else { return 0; }
        }

        private static void SwitchCase(int choice)
        {
            switch (choice)
            {
                case 1:
                    Food bread = new("Batonas", 1.99, new DateTime(2023, 12, 24));

                    Console.WriteLine($"{bread.GetName()} which price {bread.GetPrice()}€" +
                        $" expires on {bread.GetExpirationTime().ToShortDateString()}");
                    break;
                case 2:
                    Electronic iphone = new("iPhone", 799, 2);

                    Console.WriteLine($"{iphone.GetName()} - {iphone.GetPrice()}€ has {iphone.GetWarranty()} year warranty");
                    break;
                case 3:
                    break;
                default:
                    Console.WriteLine("Something went wrong...");
                    break;
            }
        }
    }
}
/*
 * Describe the vehicle rental system.
 * Your system should have classes of customers, 
 * classes of vehicles, classes of different payment methods.
 * Create a short scenario where you as a customer can
 * reserve the vehicle you want and depending on the vehicle
 * it should throw a message when the methods "Drive()",
 * "PrintMaxSpeed", "GetCapacity" and "GetFuelEfficiency" are used.
 */