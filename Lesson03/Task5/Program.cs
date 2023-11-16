namespace Task5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Please enter year: ");
            int year = Convert.ToInt32(Console.ReadLine());

            if ((year % 4 == 0 && year % 100 != 0) || year % 400 == 0)
                Console.WriteLine("This is a leap year");
            else
                Console.WriteLine("This is not a leap year");
        }
    }
}