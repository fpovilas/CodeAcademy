namespace Task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Variables

            byte choice;
            int power, powerBase, result, index, number, group, temp, j;

            #endregion

            Console.WriteLine("3.1 While loop till gets integer value\n" +
                            "3.2 Math.Pow() converted to while\n" +
                            "3.3 Task");

            Console.Write("Choose the task: ");
            choice = Convert.ToByte(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("Please enter a number: ");
                    while(!(int.TryParse(Console.ReadLine(), out number)))
                    {
                        Console.WriteLine("Wrong input. Please enter integer.");
                    }

                    Console.WriteLine($"You entered: {number}");

                    break;
                case 2:
                    Console.Write("Please enter the base of power: ");
                    powerBase = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Please enter the power: ");
                    power = Convert.ToInt32(Console.ReadLine());
                    
                    result = 1;
                    index = power;
                    while(index > 0)
                    {
                        result *= powerBase;

                        index--;
                    }

                    Console.WriteLine($"Math.Pow({powerBase}, {power}) = {result}");
                    break;
                case 3:
                    Console.Write("Please input a Nubmer: ");
                    number = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Please input a Group: ");
                    group = Convert.ToInt32(Console.ReadLine());

                    temp = 1;

                    while(group > 0)
                    {
                        j = temp;
                        while(j > 0)
                        {
                            Console.Write(number);
                            j--;
                        }
                        temp++;
                        group--;

                        if(group != 0)
                            Console.Write(" -> ");
                    }
                    break;
                default:
                    Console.WriteLine("There is only 3 tasks");
                    break;
            }
        }
    }
}