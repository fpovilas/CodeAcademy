using System.Diagnostics.Metrics;

namespace Task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Variables

            string choice;
            int[,] valueArray;
            int maxValueInArray;
            int[,] symetricalArray;

            #endregion

            PrintMenu();

            choice = GetChoice();

            switch (choice)
            {
                case "3.1":
                    valueArray = new int[,]{
                                {1, 2, 3},
                                {4, 20, 6},
                                {7, 8, 9}};

                    maxValueInArray = GetMaxValue(valueArray);

                    Console.WriteLine(maxValueInArray);
                    break;
                case "3.2":
                    symetricalArray = new int[,] { { 1, 1, 1 }, { 1, 1, 1 }, { 1, 1, 1 }, };

                    if(isSymetrical(symetricalArray))
                        Console.WriteLine("Array is symetrical");
                    else
                        Console.WriteLine("Array is not symetrical");

                    break;
                case "3.3":
                     break;
                case "3.4":
                    break;
                default:
                    Console.WriteLine("There is only 4 tasks or wrong choice");
                    break;
            }
        }

        private static void PrintMenu()
        {
            Console.WriteLine("""
                3.1 Find max value in 2D array
                3.2 Check if array is symmetrical
                3.3 
                3.4 
                """);
        }

        private static string GetChoice()
        {
            Console.Write("Please eneter your choice: ");
            return Console.ReadLine();
        }

        private static int GetMaxValue(int[,] valueArray)
        {
            int maxValue = int.MinValue;
            int[] valueArray1D = Get1DArray(valueArray);

            for(int i = 0; i < valueArray1D.Length; i++)
            {
                if (maxValue < valueArray1D[i])
                    maxValue = valueArray1D[i];
            }

            return maxValue;
        }

        private static int[] Get1DArray(int[,] valueArray)
        {
            int[] newArray = new int[valueArray.GetLength(0) * valueArray.GetLength(1)];
            int counter = 0;

            for(int i = 0; i < valueArray.GetLength(0); i++)
            {
                for (int j = 0; j < valueArray.GetLength(1); j++)
                {
                    newArray[counter] = valueArray[i, j];
                    counter++;
                }
            }

            return newArray;
        }

        private static bool isSymetrical(int[,] valueArray)
        {
            int symmetrical = 0;
            bool symetrical = false;
            for(int i = 0; i < valueArray.GetLength(0) / 2; i++)
            {
                for(int j = 0; j < valueArray.GetLength(1) / 2; j++)
                {
                    if (valueArray[i,j] == valueArray[valueArray.GetLength(0) - i - 1, valueArray.GetLength(1) - j - 1])
                    {
                        symmetrical++;
                    }

                    else { return false; }
                }
            }

            if(symmetrical == valueArray.GetLength(0) / 2)
                symetrical = true;

            return symetrical;
        }
    }
}