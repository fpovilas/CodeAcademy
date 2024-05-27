namespace Task2.Class
{
    internal abstract class Human
    {
        public string Name { get; set; }
        public List<Vehicle> Vehicles { get; set; } = new List<Vehicle>();

        public Human(string name)
        {
            Name = name;
        }

        public abstract void AddVehicle(Vehicle vehicle);

        public abstract void RemoveVehicle(Vehicle vehicle);
    }
}
