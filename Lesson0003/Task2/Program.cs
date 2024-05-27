namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Choose Task 2.1 by entering 1.\nChooce Task 2.2 by entering 2.\nYour choice: ");
            int choice = Convert.ToInt16(Console.ReadLine());
            if (choice == 1)
            {
                Console.Write("Enter a number: ");
                int num = Convert.ToInt16(Console.ReadLine());

                if (num % 2 == 0)
                    Console.WriteLine($"The number {num} is even");
                else if (num % 5 == 0)
                    Console.WriteLine($"The number {num} is divisable by 5");
                else Console.WriteLine($"The number {num} does not meet any conditions");
            }
            else if (choice == 2)
            {
                Console.Write("Enter temperature: ");
                int temp = Convert.ToInt16(Console.ReadLine());
                if (temp <= 0)
                    Console.WriteLine("Cold");
                else if (temp > 0 && temp <= 20)
                    Console.WriteLine("Cool");
                else Console.WriteLine("Hot");
            }
            else { Console.WriteLine("Wrong choice"); }
        }
    }
}