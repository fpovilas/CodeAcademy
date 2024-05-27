namespace Task3.Class
{
    internal class Square
    {
        public double KrastineA {  get; set; }
        public double KrastineB { get; set; }

        public Square(double a, double b)
        {
            KrastineA = a;
            KrastineB = b;
        }

        public double Area()
        {
            return KrastineA * KrastineB;
        }

        public double Perimeter()
        {
            return 2 * (KrastineA + KrastineB);
        }
    }
}
