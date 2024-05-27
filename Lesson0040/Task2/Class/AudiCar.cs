namespace Task2.Class
{
    public class AudiCar(bool isQuattro, string model, int fuel) : Car
    {
        public override string Model { get; set; } = model;
        public override int Fuel { get; set; } = fuel;
        public bool IsQuattro { get; set; } = isQuattro;

        public override void Drive()
        {
            Console.WriteLine($"{Model} is in drive mode");
        }

        public override void Refuel(int refill)
        {
            Console.WriteLine($"{Model} is refueled");
            Fuel += refill;
        }

        public override string ToString()
        {
            return $"{Model} has {Fuel}l";
        }
    }
}
