namespace Task5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name1 = "John";
            string name2 = "john"; 

            if(name1.ToLower().Equals(name2.ToLower())) // Added ToLower to both strings
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