namespace Task1.Class
{
    internal class Rectangle
    {
        private double Height { get; set; }
        private double Width { get; set; }

        public Rectangle(double height, double width)
        {
            Height = height;
            Width = width;
        }

        public void PrintPerimeter()
        {
             Console.WriteLine($"Perimeter of rectangle is {2 * (Height + Width)}");
        }

        public void PrintArea()
        {
            Console.WriteLine($"Area of rectangle is {Height * Width}");
        }
    }
}
