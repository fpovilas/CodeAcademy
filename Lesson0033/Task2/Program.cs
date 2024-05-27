using Task2.Class;

namespace Task2
{
    internal class Program
    {
        static void Main()
        {
            FourSideGeometricFigure geo = new("Square", 4, 5);
            Console.WriteLine(geo.GetArea());
            Generator<FourSideGeometricFigure>.Show(geo);
        }
    }
}
/*
 * Create class FourSideGeometricFigure
 ** Properties:
 ** Name
 ** Base
 ** Height
 *
 * Functions:
 ** GetArea()
 * Also override the ToString() function to return the described object.
 * Then create a method Show in the Generator<T> class that prints the value returned by the passed ToString() object.
 */
