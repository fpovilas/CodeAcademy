namespace Task6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a number: ");
            int num = Convert.ToInt16(Console.ReadLine());

            if (num % 5 == 0 && num % 3 == 0)
                Console.WriteLine("BazingaPop");
            else if (num % 3 == 0)
                Console.WriteLine("Bazinga");
            else if (num % 5 == 0)
                Console.WriteLine("Pop");
            else
                Console.WriteLine(num);
        }
    }
}