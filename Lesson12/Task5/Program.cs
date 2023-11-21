namespace Task5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name1 = "John";
            // string name2 = "john"; // Wrong Line
            string name2 = name1;

            if(name1.Equals(name2))
            {
                Console.WriteLine("Names are the same.");
            }
            else
            {
                Console.WriteLine("Names are different");
            }
        }
    }
}