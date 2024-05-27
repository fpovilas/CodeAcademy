namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Variables

            int[] array;
            int[] arrayToSum;
            int[] arrayToGetLargestNum;
            int[] poweredBy2Array;
            int[] toPrintBackwards;

            #endregion

            PrintMenu();
            GetChoice(out string? choice);

            switch (choice)
            {
                case "1":
                case "1.1":
                    array = new int[] { 1, 2, 3, 4, 5 };
                    poweredBy2Array = GetPoweredArray(array);

                    for(int i = 0; i < poweredBy2Array.Length; i++)
                    {
                        Console.WriteLine($"Given value: {array[i], 2} | Powered value: {poweredBy2Array[i], 2}");
                    }
                    break;
                case "2":
                case "1.2":
                    arrayToSum = new int[] {60, 160, 100, 30, 25, 45};

                    Console.WriteLine($"{nameof(arrayToSum)} sum is {SumOfArray(arrayToSum)}");
                    break;
                case "3":
                case "1.3":
                    arrayToGetLargestNum = new int[] { 60, 160, 100, 30, 25, 45 };

                    Console.WriteLine($"In {nameof(arrayToGetLargestNum)}" +
                        $" largest number is {GetLargestNumberInArray(arrayToGetLargestNum)}");
                    break;
                case "4":
                case "1.4":
                    toPrintBackwards = new int[] { 1, 90, 10, 666, 420, 999, 1337 };

                    PrintIntArrayBackwards(toPrintBackwards);
                    break;
                default:
                    Console.WriteLine("There is only 4 tasks!");
                    break;
            }

        }

        private static void PrintMenu()
        {
            Console.WriteLine("""
                1.1 Return new squared array;
                1.2 Sum of int Array
                1.3 Return largest element of int Array
                1.4 Print int Array backwards
                """);
        }

        private static void GetChoice(out string? choice)
        {
            Console.Write("Please enter your choice: ");
            choice = Console.ReadLine();
        }

        private static int[] GetPoweredArray(int[] array)
        {
            int[] newArray = new int[array.Length];

            for(int i = 0; i < array.Length; i++)
            {
                newArray[i] = array[i] * array[i];
            }

            return newArray;
        }

        private static int SumOfArray(int[] array)
        {
            int sum = 0;
            for(int i = 0; i < array.Length; i++)
                sum += array[i];

            return sum;
        }

        private static int GetLargestNumberInArray(int[] array)
        {
            return array.Max();
        }
        
        private static void PrintIntArrayBackwards(int[] arr)
        {
            Console.Write("Priting array backwards: ");
            for(int i = arr.Length - 1; i >= 0; i--)
            {
                Console.Write(arr[i]);
                if (i > 0)
                    Console.Write(", ");
            }
        }
    }
}