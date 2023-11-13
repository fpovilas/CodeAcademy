namespace Task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Variables

            byte choice;
            int power, powerBase, result, index;

            #endregion

            Console.WriteLine("3.1 Task\n" +
                            "3.2 Math.Pow() converted to while\n" +
                            "3.3 Task");

            Console.Write("Choose the task: ");
            choice = Convert.ToByte(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    // Nesupratau užduoties
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
                    // Nesupratau užduoties
                    break;
                default:
                    Console.WriteLine("There is only 3 tasks");
                    break;
            }
        }
    }
}