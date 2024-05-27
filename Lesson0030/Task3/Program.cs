using System.Linq.Expressions;
using Task3.Class;

namespace Task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PrintMenu();
            int choice = GetChoice();

            SwitchCase(choice);
        }

        private static void PrintMenu()
        {
            Console.Out.WriteLine("""
                1. Shape example
                2. Animal example
                """);
        }

        private static int GetChoice()
        {
            Console.Write("Your choice: ");
            if(int.TryParse(Console.ReadLine(), out int choice))
            { return choice; }
            return 0;
        }

        private static void SwitchCase(int choice)
        {
            switch (choice)
            {
                case 1:
                    Circle circle = new(9.9);
                    Console.WriteLine($"{circle.CalculateArea():0.000}");
                    break;
                case 2:
                    Dog dog = new();
                    dog.MakeSound();
                    break;
                default:
                    Console.WriteLine($"Something wrong... {choice}");
                    break;
            }
        }
    }
}

/*
 * Create a base class called "Shape" with the virtual method
 * "CalculateArea()". Implement this method to return the area.
 * Create a derived class named "Circle" which inherits from "Shape"
 * and overrides the method "CalculateArea()". This class must lock
 * the CalculateArea() method to ensure that the method
 * cannot be overridden again.
 * 
 * Create a base class called "Animal" with the virtual method
 * "MakeSound()". Implement this method to output the sound of
 * the animal. Create a derived class named "Dog" which inherits
 * from "Animal" and overrides the method "MakeSound()". Lock the
 * "MakeSound()" method so that no additional derived classes can
 * be created with dog sounds.
*/