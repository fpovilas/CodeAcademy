using Task3.Class;

namespace Task3
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
                1. Example with Transport and Car class
                2. Example with Employee class
                3. Extended Employee class with Manager class
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
                    Transport transport = new();
                    transport.SetSpeed(10);
                    Console.WriteLine(transport.MeasureSpeed());

                    Car car = new Car();
                    car.Name = "Opel";
                    car.SetSpeed(200);
                    Console.WriteLine(car.MeasureSpeed());
                    break;
                case 2:
                    Employee employee = new();
                    employee.Name = "Povilas";
                    employee.Greeting();
                    break;
                case 3:
                    Manager manager = new();
                    manager.Name = "Julian";
                    manager.Greeting();
                    break;
                default:
                    Console.WriteLine("Something went wrong...");
                    break;
            }
        }
    }
}