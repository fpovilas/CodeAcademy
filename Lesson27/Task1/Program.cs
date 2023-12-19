using Task1.Class;

namespace Task1
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
                1. Example with Vehicle, Car and Bike classes
                2. Example with Employee and Manager classes
                3. Extended Employee and Manager classes with Programmer class
                """);
        }

        private static int GetChoice()
        {
            Console.Write("Please enter your choice: ");
            if(int.TryParse(Console.ReadLine(), out int choice)) {  return choice; }
            else { return 0; }
        }

        private static void SwitchCase(int choice)
        {
            switch (choice)
            {
                case 1:
                    Car car = new(220);
                    Console.WriteLine($"Speed of {nameof(car)} is {car.GetSpeed()}");

                    Bike bike = new(320);
                    Console.WriteLine($"Speed of {nameof(bike)} is {bike.GetSpeed()}");
                    break;
                case 2:
                    Manager manager = new("Petras", 2500);
                    List<Employee> employees = new()
                    {
                        new ("Povilas", 1000),
                        new ("Ieva", 1250),
                        new ("Lukas", 1100),
                        new ("Kostas Domas", 3600)
                    };
                    manager.SetEmployees(employees);

                    Console.WriteLine($"{manager.GetName()} salaray is {manager.GetSalary()}€." +
                        $" Also manages {manager.GetEmployeesNumber()} employee\\s:");
                    manager.GetEmployees();
                    break;
                case 3:
                    Programmer programmer = new("Povilas", 2500, "C#");
                    Console.WriteLine($"{programmer.GetName()} salary is {programmer.GetSalary()}€ " +
                        $"and he programms in {programmer.GetProgrammingLanguage()}");

                    Manager newManager = new("Povilas", 6969.69);
                    List<Programmer> newEmployees = new()
                    {
                        new ("Stasys", 3000, "C#"),
                        new ("Cate", 3000, "C++"),
                        new ("John", 3000, "C"),
                        new ("Michael", 3000, "F#"),
                        new ("Joshua", 3000, "R#"),
                    };
                    newManager.SetEmployees(newEmployees);

                    Console.WriteLine($"{newManager.GetName()} salaray is {newManager.GetSalary()}€." +
                        $" Also manages {newManager.GetEmployeesNumber(true)} employee\\s:");

                    newManager.GetEmployees(true);
                    break;
                default:
                    Console.WriteLine("Something went wrong...");
                    break;
            }
        }
    }
}