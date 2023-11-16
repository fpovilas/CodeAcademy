namespace Task4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Please enter your age: ");
            int age = Convert.ToInt16(Console.ReadLine());

            if (age >= 0 && age <= 18)
                Console.WriteLine("You are a minor");
            else if (age > 18 && age <= 65)
                Console.WriteLine("You are an adult");
            else if (age > 65)
                Console.WriteLine("You are eligible for the Seniot Citizen promotion");
            else Console.WriteLine("You entered wrong number");
        }
    }
}