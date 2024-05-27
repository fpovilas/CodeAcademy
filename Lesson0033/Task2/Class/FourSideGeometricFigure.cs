namespace Task2.Class
{
    internal class FourSideGeometricFigure
    {
        private string Name { get; set; }
        private double Base { get; set; }
        private double Height { get; set; }

        public FourSideGeometricFigure(string name, double @base, double height)
        {
            Name = name;
            Base = @base;
            Height = height;
        }

        public string GetName() => Name;
        public double GetBase() => Base;
        public double GetHeight() => Height;

        public void SetName(string name) => Name = name;
        public void SetBase(double @base) => Base = @base;
        public void SetHeight(double height) => Height = height;

        public double GetArea() => Base * Height;

        public override string ToString() => $"{Name} height {Height} base {Base}";
    }
}
