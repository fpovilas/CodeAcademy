namespace Task2.Class
{
    internal class Vehicle
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public DateTime MakeYear { get; set; }
        public int Speed { get; set; }
        public double FuelTank { get; set; }
        public double FuelEfficiency { get; set; }

        public Vehicle(string brand, string model,
                    DateTime makeYear, int speed,
                    double fuelTank, double fuelEfficiency)
        {
            Brand = brand;
            Model = model;
            MakeYear = makeYear;
            Speed = speed;
            FuelTank = fuelTank;
            FuelEfficiency = fuelEfficiency;
        }

        public void PrintMaxSpeed()
        { Console.WriteLine(Speed); }

        public double GetCapacity()
        { return FuelTank; }

        public double GetFuelEfficiency()
        { return FuelEfficiency; }
    }
}
