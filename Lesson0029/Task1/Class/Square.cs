namespace Task1.Class
{
    internal class Square : GeometricShape
    {
        private double Length { get; set; }

        public Square(double length)
        {
            Length = length;
        }

        public double GetHeight() => Length;

        public override double GetArea() => Length * Length;

        public override double GetPerimeter() => 4 * Length;
    }
}
