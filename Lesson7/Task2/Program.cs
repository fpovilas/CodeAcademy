namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Variables

            byte choice;
            uint factorial, factor;
            string number;
            byte index = 0, j, temp;

            #endregion

            Console.WriteLine("2.1 Task\n" +
                            "2.2 Task\n" +
                            "2.3 Task");

            Console.Write("Choose the task: ");
            choice = Convert.ToByte(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    while (index != -1)
                    {
                        factorial = 1;
                        Console.Write("Please enter the number: ");
                        factor = Convert.ToUInt32(Console.ReadLine());

                        while (factor > 0)
                        {
                            factorial *= factor;
                            factor--;
                        }

                        if(factorial <= 0)
                            Console.WriteLine("Buffer overflow");
                        else
                            Console.WriteLine(factorial.ToString());
                    }
                    break;
                case 2:
                    Console.Write("Please enter a number: ");
                    number = Console.ReadLine();

                    index = 0;
                    while(number.Length != index)
                    {
                        if(number.Length != index + 1)
                            Console.Write($"{number[index]}, ");
                        else
                            Console.Write($"{number[index]}.");

                        index++;
                    }
                    break;
                case 3:
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
                    Console.WriteLine("There is only 3 tasks");
                    break;
            }
        }
    }
}