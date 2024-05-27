namespace Task9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Please enter length of first side of the triangle: ");
            int a = Convert.ToInt16(Console.ReadLine());
            Console.Write("Please enter length of second side of the triangle: ");
            int b = Convert.ToInt16(Console.ReadLine());
            Console.Write("Please enter length of third side of the triangle: ");
            int c = Convert.ToInt16(Console.ReadLine());

            if (a + b > c && a + c > b && b + c > a)
                Console.WriteLine("Can form a triangle");
            else
                Console.WriteLine("Cannot form a trangle");
        }
    }
}