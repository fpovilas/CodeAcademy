namespace Task2.Class
{
    internal class Carhead : Human
    {
        public Carhead(string name) : base(name)
        {
        }

        public override void AddVehicle(Vehicle car)
        {
            if(car is Car)
                Vehicles.Add(car);
            else Console.WriteLine("There is nothing to add");
        }

        public override void RemoveVehicle(Vehicle car)
        {
            if (Vehicles.Contains(car) && car is Car)
            { Vehicles.Remove(car); }
            else Console.WriteLine("There is nothing to remove");
        }
    }
}