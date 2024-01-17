using Task2.Interface;
using Task3.Interface;

namespace Task2.Class
{
    internal class Hexagon(double side) : IPolygon, IComparable<Hexagon>, IWriteable
    {
        public double Side { get; set; } = side;

        public int CompareTo(Hexagon? other)
        {
            if (GetArea() == null || other?.GetArea() == null) return 0;
            if (GetArea() < other?.GetArea()) return -1;
            if (GetArea() > other?.GetArea()) return 1;
            return 0;
        }

        public double? GetArea() => 3 * Math.Sqrt(3) / 2 * Math.Pow(2, Side);

        public override string ToString() => $"{GetArea():#.###}";

        public void WriteToFile(string fileName)
        {
            using StreamWriter writer = new(fileName, true);
            writer.WriteLine(ToString());
        }
    }
}
