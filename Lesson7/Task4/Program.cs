namespace Task4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Variables

            byte choice;
            int index, temp, j;

            #endregion

            Console.WriteLine("4.1 Task\n" +
                            "4.2 Math.Pow() converted to while\n");

            Console.Write("Choose the task: ");
            choice = Convert.ToByte(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("Please enter the number: ");
                    index = Convert.ToByte(Console.ReadLine());
                    temp = 1;

                    while (index > 0)
                    {
                        j = temp;
                        while (j > 0)
                        {
                            Console.Write(temp);
                            j--;
                        }
                        temp++;
                        index--;
                        Console.WriteLine();
                    }
                    break;
                case 2:
                    
                    break;
                default:
                    Console.WriteLine("There is only 2 tasks");
                    break;
            }
        }
    }
}