namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Choose Task 1.1 by entering 1.\nChooce Task 1.2 by entering 2.\nYour choice: ");
            int choice = Convert.ToInt16(Console.ReadLine());
            if (choice == 1)
            {
                Console.Write("Enter the number: ");
                int num = Convert.ToInt16(Console.ReadLine());

                if (num < 100)
                    Console.WriteLine("Number is less then 100");
                else if (num > 100)
                    Console.WriteLine("Number is greater then 100");
                else Console.WriteLine("Number is equal to 100");
            }
            else if (choice == 2)
            {
                Console.Write("Enter number of day of the week: ");
                int day = Convert.ToInt16(Console.ReadLine());

                if (day == 1)
                    Console.WriteLine("Monday");
                else if (day == 2)
                    Console.WriteLine("Tuesday");
                else if (day == 3)
                    Console.WriteLine("Wednesday");
                else if (day == 4)
                    Console.WriteLine("Thursday");
                else if (day == 5)
                    Console.WriteLine("Friday");
                else if (day == 6)
                    Console.WriteLine("Saturday");
                else if (day == 7)
                    Console.WriteLine("Sunday");
                else Console.WriteLine("Wrong day number");
            }
            else { Console.WriteLine("Wrong choice"); }
        }
    }
}