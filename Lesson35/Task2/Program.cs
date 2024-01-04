namespace Task2
{
    internal class Program
    {
        static void Main()
        {
            int[] arr = [ 1, 2, 3, 4, 5 ];

            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }

            int index = 7;
            try
            {
                Console.WriteLine(arr[index]);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + $" Used index {index}");
            }

            Console.WriteLine("Done...");
        }
    }
}
