namespace Task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // int counter = 0; //Wrong Line
            int counter = 1;
            while ( counter <= 10  )
            {
                Console.WriteLine("Count: " + counter);
                // counter--; // Wrong Line
                counter++;
            }
        }
    }
}