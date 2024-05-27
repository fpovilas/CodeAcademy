namespace Task8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Choose Task 8.1 by entering 1.\nChooce Task 8.2 by entering 2.\nYour choice: ");
            int choice = Convert.ToInt16(Console.ReadLine());
            if (choice == 1)
            {
                Console.Write("Please enter first number: ");
                int a = Convert.ToInt16(Console.ReadLine());
                Console.Write("Please enter second number: ");
                int b = Convert.ToInt16(Console.ReadLine());
                Console.Write("Please enter third number: ");
                int c = Convert.ToInt16(Console.ReadLine());

                if ( (a > 0 && b > 0) ||
                     (a > 0 && c > 0) ||
                     (b > 0 && c > 0) ||
                     (a > 0 && b > 0 && c > 0) )
                {
                    int sum = a + b + c;
                    Console.WriteLine(sum);
                }
                else
                    Console.WriteLine("Could not calculate sum");
            }
            else if (choice == 2)
            {
                Console.Write("Please enter year: ");
                int year = Convert.ToInt32(Console.ReadLine());
                Console.Write("Please write month: ");
                string month = Console.ReadLine();

                if (month.ToLower() == "january" || month.ToLower() == "february" || month.ToLower() == "march")
                    Console.WriteLine("Cold period");
                else if (month.ToLower() == "june" || month.ToLower() == "july" || month.ToLower() == "august")
                    Console.WriteLine("Hot period");
                else
                    Console.WriteLine("Medium period");
            }
            else { Console.WriteLine("Wrong choice"); }
        }
    }
}