using Task2.Interface;
using Task3.Interface;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Task2.Class
{
    internal class Quadrilateral(double a, double b) : IPolygon, IComparable<Quadrilateral>, IWriteable
    {
        public double A { get; set; } = a;
        public double B { get; set; } = b;

        public int CompareTo(Quadrilateral? other)
        {
            if (GetArea() == null || other?.GetArea() == null) return 0;
            if (GetArea() < other?.GetArea()) return -1;
            if (GetArea() > other?.GetArea()) return 1;
            return 0;
        }

        public double? GetArea() => A * B;

        public override string ToString() => GetArea().ToString()!;

        public void WriteToFile(string fileName)
        {
            using StreamWriter writer = new(fileName, true);
            writer.WriteLine(ToString());
        }
    }
}
