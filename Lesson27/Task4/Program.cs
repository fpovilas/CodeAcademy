using Task4.Class;
using Task2.Class;

namespace Task4
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
                1. Base Shape class. Circle, Rectangle class
                """);
        }

        private static int GetChoice()
        {
            Console.Write("Please enter your choice: ");
            if (int.TryParse(Console.ReadLine(), out int choice)) { return choice; }
            else { return 0; }
        }

        private static void SwitchCase(int choice)
        {
            switch (choice)
            {
                case 1:
                    Circle circle = new Circle();
                    circle.Diameter = 10;
                    circle.Draw();

                    Rectangle rectangle = new Rectangle();
                    rectangle.Height = 10;
                    rectangle.Lenght = 15;
                    rectangle.Draw();
                    break;
                case 2:
                    Vehicle vehicle = new();
                    break;
                default:
                    Console.WriteLine("Something went wrong...");
                    break;
            }
        }
    }
}
/*
 * Create a base class called "Shape" with the
 * virtual method "Draw()". Implement this method
 * to output the standard shape information. Create
 * derived classes named "Circle" and "Rectangle" which
 * override the "Draw()" method and output the
 * information of a circle and a rectangle, respectively,
 * and display them on the screen. Create objects
 * from both derived classes and call the "Draw()" method.
 */