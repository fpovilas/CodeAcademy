namespace Task2.Class
{
    internal class Car : Vehicle
    {
        public string Type { get; set; }

        public Car(string brand, string model,
                    DateTime make, int speed,
                    int powerInKW, string type) : base(brand, model, make,
                                                    speed, powerInKW)
        {
            Type = type;
        }

        public override void Information()
        {
            Console.WriteLine($"{Brand} {Model} is {Type} car." +
                $" Which is made {Make.ToShortDateString()}." +
                $" It's max speed is {Speed} and it has {PowerInKW} kW power");
        }
    }
}
