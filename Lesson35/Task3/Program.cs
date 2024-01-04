namespace Task3
{
    internal class Program
    {
        static void Main()
        {
            int[] arr = [ 19, 0, 75, 52 ];

            try
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    Console.WriteLine(arr[i] / arr[i + 1]);
                }
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { Console.WriteLine("Finally Done"); }
        }
    }
}
