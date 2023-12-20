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
            1. Vehicle, Car and Bike class abstraction example
            2. Human, Vehicle, Car and Bike class abstraction example
            3. Human abstract class with Vehicle class
            """);
        }

        private static int GetChoice()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("Your choice: ");
            Console.ResetColor();
            if (int.TryParse(Console.ReadLine(), out int choice))
                return choice;
            return 0;
        }

        private static void SwitchCase(int choice)
        {
            switch (choice)
            {
                case 1:
                    Car opel = new("Opel", "Astra", new(2023, 12, 15), 235, 98, "Sedan");
                    opel.Information();

                    Bike honda = new("Honda", "CBF500A", new(2012, 6, 6), 260, 45, "Street");
                    honda.Information();
                    break;
                case 2:
                    Motorhead motorhead = new("Josh", new List<Vehicle>());

                    Car car = new("Honda", "Civic", new(2005, 9, 9), 198, 78, "Hatchback");
                    Bike bike = new("Suzuki", "Hayabusa", new(2022, 2, 2), 312, 129, "Sport");

                    motorhead.AddVehicle(car);
                    motorhead.AddVehicle(bike);

                    foreach (Vehicle v in motorhead.Vehicles)
                        v.Information();
                    break;
                case 3:
                    Carhead carhead = new("John");
                    Car hondaCar = new("Honda", "Civic", new(2005, 9, 9), 198, 78, "Hatchback");
                    carhead.AddVehicle(hondaCar);
                    foreach(Vehicle c in carhead.Vehicles)
                        c.Information();

                    Bikehead bikehead = new("Jeremy");
                    Bike suzukiBike = new("Suzuki", "Hayabusa", new(2022, 2, 2), 312, 129, "Sport");
                    bikehead.AddVehicle(suzukiBike);

                    foreach (Vehicle b in bikehead.Vehicles)
                        b.Information();
                    break;
                default:
                    Console.WriteLine($"Something went wrong... ({choice})");
                    break;
            }
        }
    }
}

/*
 * Create an abstract class Vehicle and think about what
 * features are common to all vehicles?
 * Create several different vehicle classes such as Bus, Truck, Scooter.
 * Think about what features are unique to these vehicles and implement them.
 * 
 * Create a Human class and assign it a list of Vechicle classes,
 * create a method that will allow any vehicle to be assigned to this class.
 * 
 * Make the Human class abstract, create several different
 * human type classes inheriting the Human class and add lists for vehicles.

 */