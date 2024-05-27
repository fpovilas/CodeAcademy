namespace Task2.Class
{
    internal class Motorhead : Human
    {
        public Motorhead(string name, List<Vehicle> vehicles) : base(name)
        {
            Vehicles = vehicles;
        }

        public override void AddVehicle(Vehicle vehicle)
        {
            Vehicles.Add(vehicle);
        }

        public override void RemoveVehicle(Vehicle vehicle)
        {
            if (Vehicles.Contains(vehicle))
            { Vehicles.Remove(vehicle); }
            else Console.WriteLine("There is nothing to remove");
        }
    }
}
