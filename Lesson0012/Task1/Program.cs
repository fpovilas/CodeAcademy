namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a = 10;
            int b = 5;
            int c = 8;

            int max = a;
            if ( b >  max )
                max = b;
            if ( c > max )
                // max = b; // Wrong line
                max = c;

            Console.WriteLine("The maxiumum value is: " + max);
        }
    }
}