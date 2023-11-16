namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Variables

            uint factorial, factor;
            int numberToCount;
            string choice, number;
            byte index = 0, j, temp;

            #endregion

            Console.WriteLine("2.1.1 Factorial of number\n" +
                            "2.1.2 Loop calculats Factorials till entered negative number\n" +
                            "2.2.1 Write number one by one\n" +
                            "2.3.1 Draw triangle");

            Console.Write("Choose the task: ");
            choice = Console.ReadLine();

            switch (choice)
            {
                case "1.1":
                    #region My Initial Solution
                    //while (index != -1)
                    //{
                    //    factorial = 1;
                    //    Console.Write("Please enter the number: ");
                    //    factor = Convert.ToUInt32(Console.ReadLine());

                    //    while (factor > 0)
                    //    {
                    //        factorial *= factor;
                    //        factor--;
                    //    }

                    //    if(factorial <= 0)
                    //        Console.WriteLine("Buffer overflow");
                    //    else
                    //        Console.WriteLine(factorial.ToString());
                    //}
                    #endregion

                    // Remade as it should be
                    Console.Write("Please enter the number: ");
                    factor = Convert.ToUInt32(Console.ReadLine());

                    // Assigning value to factorial
                    factorial = 1;

                    // Calculating factorial
                    while(factor > 0)
                    {
                        factorial *= factor;
                        factor--;
                    }
                    Console.WriteLine($"Factorial is: {factorial}");
                    break;
                case "1.2":
                    Console.Write("Please enter the number (to exit enter negative number): ");
                    numberToCount = Convert.ToInt32(Console.ReadLine());

                    while (numberToCount > 0)
                    {
                        // Assigning value to factorial
                        factorial = 1;

                        // Assining value to factor
                        factor = Convert.ToUInt32(numberToCount);

                        // Calculating factorial
                        while (factor > 0)
                        {
                            factorial *= factor;
                            factor--;
                        }
                        Console.WriteLine($"Factorial is: {factorial}");

                        // Asking again
                        Console.Write("Please enter the number (to exit enter negative number): ");
                        numberToCount = Convert.ToInt32(Console.ReadLine());
                    }
                    break;
                case "2.1":
                    Console.Write("Please enter a number: ");
                    number = Console.ReadLine();

                    index = 0;
                    while (number.Length != index)
                    {
                        if (number.Length != index + 1)
                            Console.Write($"{number[index]}, ");
                        else
                            Console.Write($"{number[index]}.");

                        index++;
                    }
                    break;
                case "3.1":
                    Console.Write("Please enter the number: ");
                    index = Convert.ToByte(Console.ReadLine());
                    temp = 1;

                    while(index > 0)
                    {
                        j = temp;
                        while(j > 0)
                        {
                            Console.Write("*");
                            j--;
                        }
                        temp++;
                        index--;
                        Console.WriteLine();
                    }
                    break;
                default:
                    Console.WriteLine("There is only 4 tasks");
                    break;
            }
        }
    }
}