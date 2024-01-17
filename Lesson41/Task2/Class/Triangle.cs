using Task2.Interface;
using Task3.Interface;

namespace Task2.Class
{
    internal class Triangle(double a, double b) : IPolygon, IComparable<Triangle>, IWriteable
    {
        public double A { get; set; } = a;
        public double B { get; set; } = b;

        public int CompareTo(Triangle? other)
        {
            if (GetArea() == null || other?.GetArea() == null) return 1;
            if (GetArea() < other?.GetArea()) return -1;
            if (GetArea() > other?.GetArea()) return 1;
            return 0;
        }

        public double? GetArea() => A * B / 2;

        public override string ToString() => GetArea().ToString()!;

        public void WriteToFile(string fileName)
        {
            using StreamWriter writer = new(fileName, true);
            writer.WriteLine(ToString());
        }
    }
}
