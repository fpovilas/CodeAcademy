using Task2.Class;
using Task3.Interface;

namespace Task2
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine($"Triangle Area {new Triangle(3,5).GetArea()}");

            Separator();

            Console.WriteLine($"Square Area {new Quadrilateral(3, 5).GetArea()}");

            Separator();

            Console.WriteLine($"Hexagon Area {new Hexagon(5).GetArea():#.###}");

            Separator();

            #region Triangle

            List<Triangle> trianglePolygons = [
                    new Triangle(5, 6),
                    new Triangle(7, 8),
                    new Triangle(6, 1),
                    new Triangle(11, 2),
                    new Triangle(6, 3),
            ];
            PrintText("Default list: ");
            PrintList(trianglePolygons);

            // Sorting Triangles
            trianglePolygons.Sort();
            PrintText("Sorted list: ");
            PrintList(trianglePolygons);

            #endregion

            Separator();

            #region Quadrilateral

            List<Quadrilateral> quadrilateralPolygons = [
                    new Quadrilateral(5, 6),
                    new Quadrilateral(7, 8),
                    new Quadrilateral(6, 1),
                    new Quadrilateral(11, 2),
                    new Quadrilateral(6, 3),
            ];
            PrintText("Default list: ");
            PrintList(quadrilateralPolygons);

            // Sorting Quadrilaterals
            quadrilateralPolygons.Sort();
            PrintText("Sorted list: ");
            PrintList(quadrilateralPolygons);

            #endregion

            Separator();

            #region Hexagon

            List<Hexagon> hexagonPolygons = [
                    new Hexagon(5),
                    new Hexagon(8),
                    new Hexagon(6),
                    new Hexagon(2),
                    new Hexagon(3),
            ];
            PrintText("Default list: ");
            PrintList(hexagonPolygons);

            // Sorting Hexagons
            hexagonPolygons.Sort();
            PrintText("Sorted list: ");
            PrintList(hexagonPolygons);

            #endregion

            Separator();

            List<IWriteable> listOfObjects = [
                new Triangle(7, 5),
                new Quadrilateral(5, 7),
                new Hexagon(2),
                new Triangle(7, 2),
                new Quadrilateral(9, 5),
                new Triangle(3, 5),
                new Hexagon(1),
                new Triangle(2, 10),
                new Quadrilateral(2, 7),
                new Hexagon(10),
                new Triangle(7, 2),
                new Quadrilateral(1, 9)
            ];
            PrintText("Default list: ");
            PrintList(listOfObjects);
            PrintText("Writing list to File");
            foreach (IWriteable writeable in listOfObjects)
                writeable.WriteToFile(@"D:\Projektai\Programavimas\CodeAcademy\Lesson41\Task2.txt");
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
