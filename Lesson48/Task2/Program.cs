namespace Task2
{
    internal class Program
    {
        static async Task Main()
        {
            for(int i = 0; i < 4; i++)
            {
                Console.Clear();
                foreach (string item in Directory.GetFiles(@"D:\Users\Povka\Desktop\"))
                {
                    Console.WriteLine(item);
                }
                await Task.Delay(1000);
            }
        }
    }

    /*
     * Create a program that prints the contents of your user's Desktop directory to the command line every 5 seconds after it is run.
     */
}
