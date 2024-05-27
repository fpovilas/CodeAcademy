namespace Task3.Class
{
    internal class Circle
    {
        double R { get; set; }

        public Circle(double r)
        {
            R = r;
        }

        public double Area()
        {
            return Math.PI * Math.Pow(R, 2);
        }

        public double Perimeter()
        {
            return 2 * R * Math.PI;
        }
    }
}
