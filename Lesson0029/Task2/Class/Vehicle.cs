namespace Task2.Class
{
    internal abstract class Vehicle
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public DateTime Make {  get; set; }
        public int Speed { get; set; }
        public int PowerInKW { get; set; }

        public Vehicle(string brand, string model,
                    DateTime make, int speed, int powerInKW)
        {
            Brand = brand;
            Model = model;
            Make = make;
            Speed = speed;
            PowerInKW = powerInKW;
        }

        public abstract void Information();
            // Console.WriteLine($"{Brand} {Model} is made {Make.ToShortDateString()}." +
            //     $" It's max speed is {Speed} and it has {PowerInKW} kW power");
    }
}
