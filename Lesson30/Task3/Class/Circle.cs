namespace Task3.Class
{
    internal class Circle : Shape
    {
        private double Radius { get; set; }

        public Circle(double radius) { Radius = radius; }

        public void SetRadius(double radius) { Radius = radius; }

        public double GetRadius() => Radius;

        public sealed override double CalculateArea()
                        => Math.PI * Math.Pow(Radius, 2);
    }
}
