using Task2.Class;
using Task2.Comparer;
using Task2.Interface;

namespace Task2
{
    internal class Program
    {
        static void Main()
        {
            IPolygonComparer polygonComparer = new();

            Console.WriteLine($"Triangle Area {new Triangle(3,5).GetArea()}");

            Separator();

            Console.WriteLine($"Square Area {new Quadrilateral(3, 5).GetArea()}");

            Separator();

            Console.WriteLine($"Hexagon Area {new Hexagon(5).GetArea():#.###}");

            Separator();

            #region Triangle

            List<IPolygon> trianglePolygons = [
                    new Triangle(5, 6),
                    new Triangle(7, 8),
                    new Triangle(6, 1),
                    new Triangle(11, 2),
                    new Triangle(6, 3),
            ];
            PrintText("Default list: ");
            PrintList(trianglePolygons);

            // Sorting Triangles
            trianglePolygons.Sort(polygonComparer);
            PrintText("Sorted list: ");
            PrintList(trianglePolygons);

            #endregion

            Separator();

            #region Quadrilateral

            List<IPolygon> quadrilateralPolygons = [
                    new Quadrilateral(5, 6),
                    new Quadrilateral(7, 8),
                    new Quadrilateral(6, 1),
                    new Quadrilateral(11, 2),
                    new Quadrilateral(6, 3),
            ];
            PrintText("Default list: ");
            PrintList(quadrilateralPolygons);

            // Sorting Quadrilaterals
            quadrilateralPolygons.Sort(polygonComparer);
            PrintText("Sorted list: ");
            PrintList(quadrilateralPolygons);

            #endregion

            Separator();

            #region Hexagon

            List<IPolygon> hexagonPolygons = [
                    new Hexagon(5),
                    new Hexagon(8),
                    new Hexagon(6),
                    new Hexagon(2),
                    new Hexagon(3),
            ];
            PrintText("Default list: ");
            PrintList(hexagonPolygons);

            // Sorting Hexagons
            hexagonPolygons.Sort(polygonComparer);
            PrintText("Sorted list: ");
            PrintList(hexagonPolygons);

            #endregion
        }

        private static void Separator()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------");
            Console.ResetColor();
        }

        private static void PrintList<Type>(List<Type> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (i < list.Count - 1)
                    Console.Write($"{list[i]}, ");
                else Console.WriteLine($"{list[i]}.");
            }
        }

        private static void PrintText(string text, bool printAsList = false)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            if (printAsList) { Console.WriteLine(text); }
            else { Console.Write(text); }
            Console.ResetColor();
        }
    }
}
