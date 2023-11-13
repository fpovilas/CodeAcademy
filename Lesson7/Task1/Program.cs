namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Variables

            byte choice;
            int index, j, number;

            #endregion

            Console.WriteLine("1.1 Nested while loops\n" +
                            "1.2 Even/Odd number loop\n" +
                            "1.3 Number 100 stops 1st loop, negative number stops inner loop");

            Console.Write("Choose the task: ");
            choice = Convert.ToByte(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    index = j = 1;
                    while (index <= 5)
                    {
                        Console.WriteLine($"1st while loop index: {index}");
                        while (j <= 5)
                        {
                            Console.WriteLine($"\t2nd while loop index: {j}");
                            j++;
                        }
                        index++;
                        j = 1;
                    }
                    break;
                case 2:
                    index = j = 1;
                    while (index <= 10)
                    {
                        if (index % 2 == 0)
                            Console.Write($"{index}\n");

                        while (j <= 10)
                        {
                            if (j == 1)
                                Console.Write("\t");

                            if (j % 2 != 0)
                                Console.Write($"{j} ");
                            j++;
                        }
                        Console.Write("\n");

                        index++;
                        j = 1;
                    }
                    break;
                case 3:
                    Console.Write("Please enter the number: ");
                    number = Convert.ToInt32(Console.ReadLine());
                    while (number != 100)
                    {
                        index = 1;

                        while (index > 0)
                        {
                            Console.Write("Please enter the number: ");
                            index = Convert.ToInt32(Console.ReadLine());
                        }

                        Console.Write("Please enter the number: ");
                        number = Convert.ToInt32(Console.ReadLine());
                    }
                    Console.WriteLine("You entered 100.");
                    break;
                default:
                    Console.WriteLine("There is onyl 3 tasks");
                    break;
            }
        }
    }
}