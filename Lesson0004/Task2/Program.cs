using System;

namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            short choice;
            Console.WriteLine("1. Task 2.1\n2. Task 2.2\n3. Task 2.3");

            choice = Convert.ToInt16(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.WriteLine("""
                        square
                        circle
                        triangle
                        rectangle
                        """);
                    Console.Write("\nPlease input name of the shape: ");
                    string shape = Console.ReadLine().ToLower();

                    switch (shape)
                    {
                        case "square":
                            double a;
                            Console.Write("\nPlease enter length of square: ");
                            a = Convert.ToDouble(Console.ReadLine());
                            
                            Console.WriteLine($"Area of square: {a * a}");
                            break;
                        case "circle":
                            double r;
                            Console.Write("\nPlease enter radius of circle: ");
                            r = Convert.ToDouble(Console.ReadLine());

                            Console.WriteLine($"Area of circle: {(2 * Math.PI * Math.Pow(r, 2)):#.###}");
                            break;
                        case "triangle":
                            double h;
                            Console.Write("\nPlease enter base length of triangle: ");
                            a = Convert.ToDouble(Console.ReadLine());
                            Console.Write("Please enter height of triangle: ");
                            h = Convert.ToDouble(Console.ReadLine());

                            Console.WriteLine($"Area of triangle: {a * h / 2}");
                            break;
                        case "rectangle":
                            double b;
                            Console.Write("\nPlease enter length of square: ");
                            a = Convert.ToDouble(Console.ReadLine());
                            Console.Write("Please enter width of rectangle: ");
                            b = Convert.ToDouble(Console.ReadLine());

                            Console.WriteLine($"Area of square: {a * b}");
                            break;
                        default:
                            Console.WriteLine("\nThere is only four shapes to choose.");
                            Console.WriteLine("Or you entered wrong word");
                            break;
                    }
                    break;
                case 2:
                    Console.WriteLine("""
                        fire
                        water
                        air
                        earth
                        aether
                        """);
                    Console.Write("\nPlease choose one of five elements: ");
                    string element = Console.ReadLine().ToLower();

                    switch (element)
                    {
                        case "fire":
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Heat");
                            Console.ForegroundColor = ConsoleColor.Gray;
                            break;
                        case "water":
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine("Wet");
                            Console.ForegroundColor = ConsoleColor.Gray;
                            break;
                        case "air":
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("Heat");
                            Console.ForegroundColor = ConsoleColor.Gray;
                            break;
                        case "earth":
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.WriteLine("Stone");
                            Console.ForegroundColor = ConsoleColor.Gray;
                            break;
                        case "aether":
                            Console.ForegroundColor = ConsoleColor.DarkMagenta;
                            Console.WriteLine("Light");
                            Console.ForegroundColor = ConsoleColor.Gray;
                            break;
                        default:
                            Console.WriteLine("You chose wrong element");
                            break;
                    }
                    break;
                case 3:
                    Console.WriteLine("""
                        Maths
                        Computer Science
                        Biology
                        Chemistry
                        """);
                    Console.Write("\nPlease choose one of four majors: ");
                    string major = Console.ReadLine().ToLower();

                    switch (major)
                    {
                        case "maths":
                            double gradeAvgOfMath, gradeAvgOfOther;
                            Console.WriteLine("Please enter your average grade of MATH: ");
                            gradeAvgOfMath = Convert.ToDouble(Console.ReadLine());
                            Console.WriteLine("Please enter your average grade of OTHER lessons: ");
                            gradeAvgOfOther = Convert.ToDouble(Console.ReadLine());

                            double chanceToAdmission = gradeAvgOfMath * 0.8 + gradeAvgOfOther * 0.4;

                            string succsess = chanceToAdmission switch
                            {
                                >= 8 => "You have a high chance to get admitted!",
                                < 8 and >= 5 => "You have a moderate chance to get admitted.",
                                < 5 and >= 3.5 => "You have a small chance to get admitted.",
                                _ => "You have no chance to get admitted."
                            };

                            Console.WriteLine(succsess);
                            break;
                        case "computer science":
                            double gradeAvgOfIT;
                            Console.WriteLine("Please enter your average grade of IT: ");
                            gradeAvgOfIT = Convert.ToDouble(Console.ReadLine());
                            Console.WriteLine("Please enter your average grade of MATH: ");
                            gradeAvgOfMath = Convert.ToDouble(Console.ReadLine());
                            Console.WriteLine("Please enter your average grade of OTHER lessons: ");
                            gradeAvgOfOther = Convert.ToDouble(Console.ReadLine());

                            chanceToAdmission = gradeAvgOfIT * 0.7 + ((gradeAvgOfMath + gradeAvgOfOther) * 0.55) * 0.273;

                            succsess = chanceToAdmission switch
                            {
                                >= 8 => "You have a high chance to get admitted!",
                                < 8 and >= 5 => "You have a moderate chance to get admitted.",
                                < 5 and >= 3.5 => "You have a small chance to get admitted.",
                                _ => "You have no chance to get admitted."
                            };

                            Console.WriteLine(succsess);
                            break;
                        case "biology":
                            double gradeAvgOfBio;
                            Console.WriteLine("Please enter your average grade of BIOLOGY: ");
                            gradeAvgOfBio = Convert.ToDouble(Console.ReadLine());
                            Console.WriteLine("Please enter your average grade of IT: ");
                            gradeAvgOfIT = Convert.ToDouble(Console.ReadLine());
                            Console.WriteLine("Please enter your average grade of OTHER lessons: ");
                            gradeAvgOfOther = Convert.ToDouble(Console.ReadLine());

                            chanceToAdmission = gradeAvgOfBio * 0.6 + ((gradeAvgOfIT + gradeAvgOfOther) * 0.55) * 0.3;

                            succsess = chanceToAdmission switch
                            {
                                >= 9 => "You have a high chance to get admitted!",
                                < 9 and >= 7 => "You have a moderate chance to get admitted.",
                                < 7 and >= 5 => "You have a small chance to get admitted.",
                                _ => "You have no chance to get admitted."
                            };

                            Console.WriteLine(succsess);
                            break;
                        case "chemistry":
                            double gradeAvgOfChem;
                            Console.WriteLine("Please enter your average grade of CHEMISTRY: ");
                            gradeAvgOfChem = Convert.ToDouble(Console.ReadLine());
                            Console.WriteLine("Please enter your average grade of IT: ");
                            gradeAvgOfIT = Convert.ToDouble(Console.ReadLine());
                            Console.WriteLine("Please enter your average grade of MATH: ");
                            gradeAvgOfMath = Convert.ToDouble(Console.ReadLine());
                            Console.WriteLine("Please enter your average grade of OTHER lessons: ");
                            gradeAvgOfOther = Convert.ToDouble(Console.ReadLine());

                            chanceToAdmission = gradeAvgOfChem * 0.62 + (gradeAvgOfIT * 0.5 + ((gradeAvgOfMath + gradeAvgOfOther) * 0.55) * 0.3) * 0.458;

                            succsess = chanceToAdmission switch
                            {
                                >= 9 => "You have a high chance to get admitted!",
                                < 9 and >= 7 => "You have a moderate chance to get admitted.",
                                < 7 and >= 5 => "You have a small chance to get admitted.",
                                _ => "You have no chance to get admitted."
                            };

                            Console.WriteLine(succsess);
                            break;
                        default:
                            Console.WriteLine("You choce wrong major");
                            break;
                    }
                    break;
                default:
                    Console.WriteLine("Wrong choice");
                    break;
            }
        }
    }
}