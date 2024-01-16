using Task2.Interface;

namespace Task2.Class
{
    internal class Hexagon(double side) : IPolygon
    {
        public double Side { get; set; } = side;

        public double GetArea() => 3 * Math.Sqrt(3) / 2 * Math.Pow(2, Side);

        public override string ToString() => $"{GetArea():#.###}";
    }
}
