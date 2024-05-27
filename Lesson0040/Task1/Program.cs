using Task1.Class;

namespace Task1
{
    internal class Program
    {
        static void Main()
        {
            Car mazda = new("Mazda RX-7", 35);

            Console.WriteLine($"{mazda.GetModel()} has {mazda.GetFuel()}l in the tank");

            mazda.Drive();

            mazda.Refuel(10);

            Console.WriteLine($"{mazda.GetModel()} has {mazda.GetFuel()}l in the tank");

            mazda.Refuel(-10);
        }
    }
}
