namespace Task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Choose Task 3.1 by entering 1.\nChoose Task 3.2 by entering 2.\nYour choice: ");
            int choice = Convert.ToInt16(Console.ReadLine());
            if (choice == 1)
            {
                Console.Write("Please enter what hour was when you woke up: ");
                int hour = Convert.ToInt16(Console.ReadLine());

                if (hour >= 0 && hour < 12)
                    Console.WriteLine("Good morning!");
                else if (hour >= 12 && hour < 18)
                    Console.WriteLine("Good afternoon!");
                else if (hour >= 18 && hour < 24)
                    Console.WriteLine($"Good evening!");
                else Console.WriteLine("Wrong time entered. Please enter only hours");
            }
            else if (choice == 2)
            {
                Console.Write("Enter your password: ");
                string pass = Console.ReadLine();

                if (pass == "Laikinas123" || pass == "Mellon")
                    Console.WriteLine("You have sucessfully logged in");
                else if (pass == "01101001 01101110")
                    Console.WriteLine("Hacked..");
                else Console.WriteLine("Password is incorrect, please try again..");
            }
            else { Console.WriteLine("Wrong choice"); }
        }
    }
}