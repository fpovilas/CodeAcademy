namespace Task3.Class
{
    internal class Triangle
    {
        double KrastineA { get; set; }
        double KrastineB { get; set; }
        double KrastineC { get; set; }

        public Triangle(double a, double b, double c)
        {
            KrastineA = a;
            KrastineB = b;
            KrastineC = c;
        }

        public double Area()
        {
            return (KrastineA * KrastineB / 2);
        }

        public double Perimeter()
        {
            return (KrastineA + KrastineB + KrastineC);
        }
    }
}
