namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string firstName = "John";
            string lastName = "Doe";
            // string fullName = firstName + lastName; // Wrong line
            string fullName = firstName + " " + lastName;
            Console.WriteLine("Full Name: " + fullName);
        }
    }
}