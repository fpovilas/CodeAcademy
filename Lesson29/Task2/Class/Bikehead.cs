namespace Task2.Class
{
    internal class Bikehead : Human
    {
        public Bikehead(string name) : base(name)
        {
        }

        public override void AddVehicle(Vehicle vehicle)
        {
            if(vehicle is Bike)
                Vehicles.Add(vehicle);
            else Console.WriteLine("There is nothing to add");
        }

        public override void RemoveVehicle(Vehicle vehicle)
        {
            if (Vehicles.Contains(vehicle) && vehicle is Bike)
            { Vehicles.Remove(vehicle); }
            else Console.WriteLine("There is nothing to remove");
        }
    }
}
