namespace Task1.Class
{
    internal class Triangle : GeometricShape
    {
        private double Height { get; set; }
        private double Width { get; set; }
        private double Diagnal {  get; set; }

        public Triangle(double height, double width, double diagnal)
        {
            Height = height;
            Width = width;
            Diagnal = diagnal;
        }

        public double GetHeight() => Height;

        public double GetWidth() => Width;

        public double GetDiagnal() => Diagnal;

        public override double GetArea() => Height * Width / 2;

        public override double GetPerimeter() => Height + Width + Diagnal;
    }
}
