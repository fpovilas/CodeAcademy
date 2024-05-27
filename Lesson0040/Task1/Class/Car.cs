using Task1.Interfaces;

namespace Task1.Class
{
    internal class Car(string model, int fuel) : IVehicle
    {
        private string Model { get; set; } = model;
        private int Fuel { get; set; } = fuel;

        public string GetModel() => Model;
        public int GetFuel() => Fuel;

        public void Drive()
        {
            if(Fuel >= 0) { Console.WriteLine($"{Model} is ready to drive. Fuel left {Fuel}l"); }
            else { Console.WriteLine("You need to refuel your car."); }
        }

        public void Refuel(int refill)
        {
            if(refill < 0)
            {
                Console.WriteLine($"You cannot refill with negative value ({refill})");
            }
            else
            {
                Fuel += refill;
                Console.WriteLine("Car has been refueled!");
            }
        }
    }
}
