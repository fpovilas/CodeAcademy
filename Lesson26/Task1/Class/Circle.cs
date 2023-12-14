namespace Task1.Class
{
    internal class Circle
    {
        private double Radius { get; set; }

        public Circle(double r)
        {
            Radius = r;
        }

        public void PrintPerimeter()
        {
            Console.WriteLine($"Circle perimeter: {2 * Math.PI * Radius:#.###}");
        }

        public void PrintArea()
        {
            Console.WriteLine($"Circle area: {Math.PI * Math.Pow(Radius, 2):#.###}");
        }
    }
}
