namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Variables
            byte choice;
            string name, surrname;
            double height, radius, width;
            int number;
            #endregion

            PrintMenu();
            Console.Write("Please enter your choice: ");
            choice = GetChoice();

            switch (choice)
            {
                case 0:
                    Console.WriteLine("You made a wrong choice.");
                    break;
                case 1:
                    Console.Write("Please enter your First name: ");
                    name = Console.ReadLine();
                    Console.Write("Please enter you Last Name: ");
                    surrname = Console.ReadLine();

                    Console.WriteLine(GetInitials(name, surrname));
                    break;
                case 2:
                    Console.Write("Please enter Radius of cylinder: ");
                    radius = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Please enter Height of cylinder: ");
                    height = Convert.ToDouble(Console.ReadLine());

                    Console.WriteLine($"Volume of Cylinder is {CalculateCylinderVolume(height, radius):#.###}");
                    break;
                case 3:
                    Console.WriteLine("Please enter the number: ");
                    number = Convert.ToInt32(Console.ReadLine());

                    if (IsNumberEven(number))
                        Console.WriteLine($"Number {number} is even");
                    else
                        Console.WriteLine($"Number {number} is odd");
                    break;
                case 4:
                    Console.Write("Please enter Width of rectangle: ");
                    width = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Please enter Height of rectabgle: ");
                    height = Convert.ToDouble(Console.ReadLine());

                    Console.WriteLine($"The Area of Rectangle is {CalculateRectangleArea(width, height):#.###}");
                    break;
                default:
                    Console.WriteLine("There is only 3 task.");
                    break;
            }
        }

        private static void PrintMenu()
        {
            Console.WriteLine("""
                2.1 GetInitials and combine the to one sentence
                2.2 Volume of cilinder
                2.3 IsNumberEven
                2.4 CalculateRectangleArea
                """);
        }

        private static byte GetChoice()
        {
            byte number;
            if (Byte.TryParse(Console.ReadLine(), out number))
                return number;
            else return 0;
        }

        private static string GetInitials(string firstName, string lastName)
        {
            return $"Your initials is {firstName.Substring(0, 1)}.{lastName.Substring(0, 1)}.";
        }

        private static double CalculateCylinderVolume(double height, double radius)
        {
            return 2 * Math.PI * Math.Pow(radius, 2) * height;
        }

        private static bool IsNumberEven(int number)
        {
            if(number % 2 == 0)
                return true;
            else return false;
        }

        private static double CalculateRectangleArea(double width, double height)
        {
            return width * height;
        }
    }
}