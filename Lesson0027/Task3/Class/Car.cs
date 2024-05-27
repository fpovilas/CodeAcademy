namespace Task3.Class
{
    internal class Car : Transport
    {
        public string Name { get; set; } = string.Empty;

        public override int MeasureSpeed()
        {
            Console.Write($"{Name} speed is ");
            return GetSpeed();
        }
    }
}
