using System.Text;

namespace Task4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            

            #region Variables

            byte choice;
            int index, temp, j, amount;

            #endregion

            Console.WriteLine("4.1 Triangle of numbers\n" +
                            "4.2 ATM\n");

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
                    Console.Write("Please enter how much do you want to withdraw: ");
                    amount = Convert.ToInt32(Console.ReadLine());

                    if (amount % 10 == 0)
                    {
                        Console.Write("Given bills: ");
                        while (amount > 0)
                        {
                            switch (amount)
                            {
                                case >= 500:
                                    amount -= 500;
                                    Console.Write("500 Eur ");
                                    break;
                                case < 500 and >= 200:
                                    amount -= 200;
                                    Console.Write("200 Eur ");
                                    break;
                                case < 200 and >= 100:
                                    amount -= 100;
                                    Console.Write("100 Eur ");
                                    break;
                                case < 100 and >= 50:
                                    amount -= 50;
                                    Console.Write("50 Eur ");
                                    break;
                                case < 50 and >= 20:
                                    amount -= 20;
                                    Console.Write("20 Eur ");
                                    break;
                                case < 20 and >= 10:
                                    amount -= 10;
                                    Console.Write("10 Eur ");
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                    else { Console.WriteLine("You cant withdraw only 500, 200, 100, 50, 20, 10 Eur note bills"); }
                    break;
                default:
                    Console.WriteLine("There is only 2 tasks");
                    break;
            }
        }
    }
}