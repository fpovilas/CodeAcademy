namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Variables

            int x, y;
            int[,] arr;

            #endregion

            Console.Write("Please enter X: ");
            x = Convert.ToInt32(Console.ReadLine());
            Console.Write("Please enter y: ");
            y = Convert.ToInt32(Console.ReadLine());

            arr = GetValueFromMultiArray(x, y);

            PrintMultidimensionalArray(arr);
        }

        private static int[,] GetValueFromMultiArray(int x, int y)
        {
            int[,] arr = new int[x, y];

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write($"Please enter {i + 1} row {j + 1} column number: ");
                    arr[i, j] = Convert.ToInt32(Console.ReadLine());
                }
            }

            return arr;
        }

        private static void PrintMultidimensionalArray(int[,] arr )
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write($"{arr[i, j],5}");
                }
                Console.WriteLine();
            }
        }
    }
}