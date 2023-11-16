namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            short choice;
            Console.WriteLine("1. Task 1.1\n2. Task 1.2\n3. Task 1.3");
            
            choice = Convert.ToInt16(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("Please input days of the week number: ");
                    byte day = Convert.ToByte(Console.ReadLine());

                    switch (day)
                    {
                        case 1:
                            Console.WriteLine("Monday");
                            break;
                        case 2:
                            Console.WriteLine("Tuesday");
                            break;
                        case 3:
                            Console.WriteLine("Wednesday");
                            break;
                        case 4:
                            Console.WriteLine("Thursday");
                            break;
                        case 5:
                            Console.WriteLine("Friday");
                            break;
                        case 6:
                            Console.WriteLine("Saturday");
                            break;
                        case 7:
                            Console.WriteLine("Sunday");
                            break;
                        default:
                            Console.WriteLine("There is only seven days in the week");
                            break;
                    }
                    break;
                case 2:
                    Console.Write("Please enter your age: ");
                    byte age = Convert.ToByte(Console.ReadLine());

                    switch (age)
                    {
                        case >= 7 and <= 18:
                            Console.WriteLine("Student");
                            break;
                        case > 18 and <= 25:
                            Console.WriteLine("College/Uni Student");
                            break;
                        case > 25 and <= 65:
                            Console.WriteLine("Employee");
                            break;
                        case > 65:
                            Console.WriteLine("Retired");
                            break;
                        default:
                            Console.WriteLine("You are still at kindergarten");
                            break;
                    }
                    break;
                case 3:
                    Console.Write("Please input days of the week number: ");
                    byte month = Convert.ToByte(Console.ReadLine());

                    switch (month)
                    {
                        case 1:
                            Console.WriteLine("January");
                            break;
                        case 2:
                            Console.WriteLine("February");
                            break;
                        case 3:
                            Console.WriteLine("March");
                            break;
                        case 4:
                            Console.WriteLine("April");
                            break;
                        case 5:
                            Console.WriteLine("May");
                            break;
                        case 6:
                            Console.WriteLine("June");
                            break;
                        case 7:
                            Console.WriteLine("July");
                            break;
                        case 8:
                            Console.WriteLine("August");
                            break;
                        case 9:
                            Console.WriteLine("September");
                            break;
                        case 10:
                            Console.WriteLine("October");
                            break;
                        case 11:
                            Console.WriteLine("November");
                            break;
                        case 12:
                            Console.WriteLine("December");
                            break;
                        default:
                            Console.WriteLine("There is only twelve month in the year");
                            break;
                    }
                    break;
                default:
                    Console.WriteLine("Wrong choice");
                    break;
            }
        }
    }
}