namespace Task1.Class
{
    public class MathOperations
    {
        public double Addition(double a, double b) => a + b;
        public double Subtraction(double a, double b) => a - b;
        public double Multiplication(double a, double b) => a * b;
        public double Division(double a, double b) => b == 0 ? 0 : a / b;
        public double PowerOf2(double a) => Math.Pow(a, 2);
        public double SquareRoot(double a) => Math.Sqrt(a);
    }
}
