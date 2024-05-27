using Task2.Class;

namespace Task2
{
    internal class Program
    {
        static void Main()
        {
            AudiCar audiQuattro = new(true, "Audi Quattro", 70);
            audiQuattro.Drive();
            Console.WriteLine("Now there are " + audiQuattro.Fuel + "l in the tank");
            audiQuattro.Refuel(5);
            Console.WriteLine("Now there are " + audiQuattro.Fuel + "l in the tank");

            BmwCar bmwE36 = new(false, "BMW e36", 35);
            bmwE36.Drive();
            Console.WriteLine("Now there are " + bmwE36.Fuel + "l in the tank");
            bmwE36.Refuel(5);
            Console.WriteLine("Now there are " + bmwE36.Fuel + "l in the tank");
        }
    }
}
