namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Variables

            string choice;
            int[] arraySubTask1;
            int[] arraySubTask2;
            int[] newArraySubTask2;
            double[] arraySubTask3;
            double[] newArraySubTask3;
            string[] arraySubTask4;
            int amountOfPostivieNums;
            string sentece;

            #endregion

            PrintMenu();

            choice = GetChoice();

            switch (choice)
            {
                case "1.1":
                    arraySubTask1 = new int[] {1, 2, 3, 4, 5};

                    Console.WriteLine($"{nameof(arraySubTask1)} average is {ReturnAVG(arraySubTask1):#.##}");
                    break;
                case "1.2":
                    arraySubTask2 = new int[] {-1, 5, -10, 6, 8, -3 };

                    amountOfPostivieNums = GetAmountOfPositiveNums(arraySubTask2);

                    newArraySubTask2 = new int[amountOfPostivieNums];

                    newArraySubTask2 = GetPostiveNumsFromArray(arraySubTask2, amountOfPostivieNums);

                    Print1DArrayINT(newArraySubTask2);
                    
                    break;
                case "1.3":
                    arraySubTask3 = new double[] { 1.2, 10.9, 5.0, 450, 100 };
                    newArraySubTask3 = AmountOfVAT(arraySubTask3);

                    Console.Write($"Without VAT: ");
                    Print1DArrayDouble(arraySubTask3);

                    Console.WriteLine();

                    Console.Write($"Amout of VAT: ");
                    Print1DArrayDouble(newArraySubTask3);
                    break;
                case "1.4":
                    Console.Write("Please enter a sentence: ");
                    sentece = Console.ReadLine();
                    arraySubTask4 = sentece.Split(' ');

                    Console.WriteLine("Words greater or equal to 5 letters:");
                    Print1DArrayStringGE5(arraySubTask4);
                    break;
                case "1.5":
                    break;
                default:
                    Console.WriteLine("There is only 5 tasks or wrong choice");
                    break;
            }
        }

        private static void PrintMenu()
        {
            Console.WriteLine("""
                1.1 Return AVG numbers in 1D INT array
                1.2 Print only positives from array
                1.3 Amount of VAT to Pay
                1.4 Take sentence return array of string where word is > 5
                1.5
                """);
        }

        private static string GetChoice()
        {
            Console.Write("Please eneter your choice: ");   
            return Console.ReadLine();
        }

        private static void Print1DArrayINT(int[] array)
        {
            foreach (var i in array) Console.Write(i + " ");
        }

        private static void Print1DArrayDouble(double[] array)
        {
            foreach (var i in array) Console.Write(i + " ");
        }

        private static double ReturnAVG(int[] arr)
        {
            int sum = 0;
            foreach(int item in arr)
            {
                sum += item;
            }

            return (double)sum / (double)arr.Length;
        }

        private static int GetAmountOfPositiveNums(int[] arr)
        {
            int amount = 0;
            foreach( int item in arr)
            {
                if(item > 0)
                    amount++;
            }

            return amount;
        }

        private static int[] GetPostiveNumsFromArray(int[] arr, int sizeOfArray)
        {
            int[] newArr = new int[sizeOfArray];
            int i = 0;
            foreach(int item in arr)
            {
                if(item > 0)
                    newArr[i++] = item;
            }

            return newArr;
        }

        private static double[] AmountOfVAT(double[] arr, double VAT = 15)
        {
            double[] newArr = new double[arr.Length];

            for(int item = 0; item < arr.Length; item++)
            {
                newArr[item] = arr[item] * (VAT / 100);
            }

            return newArr;
        }

        private static void Print1DArrayStringGE5(string[] arr)
        {
            foreach(string item in arr)
            {
                if(item.Length >= 5)
                    Console.WriteLine(item);
            }
        }
    }
};