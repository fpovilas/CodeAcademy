namespace Task2.Class
{
    public abstract class Car
    {
        public abstract string Model { get; set; }
        public abstract int Fuel { get; set; }

        public abstract void Refuel(int refill);
        public abstract void Drive();
    }
}
