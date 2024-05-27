using Task1.Class;

namespace Task1
{
    internal class Program
    {
        static void Main()
        {
            PrintMenu();
            int choice = GetChoice();

            SwitchCase(choice);
        }

        private static void PrintMenu()
        {
            Console.WriteLine("""
            1. Example with GeometricShape class
            2. Example with Animal class
            3. Example with GeometricShape class aded to List
            """);
        }

        private static int GetChoice()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("Your choice: ");
            Console.ResetColor();
            if (int.TryParse(Console.ReadLine(), out int choice))
                return choice;
            return 0;
        }

        private static void SwitchCase(int choice)
        {
            switch (choice)
            {
                case 1:
                    Square square = new(5.5);
                    Console.WriteLine($"{nameof(square)}" +
                        $" area is {square.GetArea()} and" +
                        $" perimeter is {square.GetPerimeter()}\n");

                    Triangle triangle = new(4, 6.5, 4.5);
                    Console.WriteLine($"{nameof(triangle)}" +
                        $" area is {triangle.GetArea()} and" +
                        $" perimeter is {triangle.GetPerimeter()}");
                    break;
                case 2:
                    Dog dog = new("Hela", "Husky-Terrier");

                    dog.MakeSound();

                    Cat cat = new("BoBo", "Jenny");

                    cat.MakeSound();
                    break;
                case 3:
                    List<GeometricShape> shapes = new()
                    {
                        new Triangle(5, 6 , 7),
                        new Triangle (6, 7 , 8),
                        new Square(9),
                        new Square(16.8),
                    };

                    foreach (GeometricShape shape in shapes)
                    {
                        Console.WriteLine($"{nameof(shape)}" +
                        $" area is {shape.GetArea()} and" +
                        $" perimeter is {shape.GetPerimeter()}\n");
                    }
                    break;
                default:
                    Console.WriteLine($"Something went wrong... ({choice})");
                    break;
            }
        }
    }
}
/*
 * Create an abstract class GeometricShape with abstract methods GetArea()
 * to calculate the area and GetPerimeter() to calculate the perimeter.
 * Create Triangle and Square classes inheriting GeometricShape and override methods.
 * 
 * Create an abstract class Animal with an abstract method MakeNoise(),
 * create classes Dog and Cat which will inherit Animal and implement methods.
 * 
 * Create a list from the GeometricShape data type,
 * add objects of the Triangle and Square classes to this list
 * and iteratively print the perimeters and areas of these classes.
*/