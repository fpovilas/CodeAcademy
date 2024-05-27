using System.Reflection;

namespace Task2.Class
{
    internal class Car : Vehicle
    {
        public string Type { get; set; }

        public Car(string brand, string model,
                    DateTime makeYear, int speed,
                    double fuelTank, double fuelEfficiency, string type)
        {
            Brand = brand;
            Model = model;
            MakeYear = makeYear;
            Speed = speed;
            FuelTank = fuelTank;
            FuelEfficiency = fuelEfficiency;
            Type = type;
        }
    }
}