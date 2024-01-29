using Task1.Class;

namespace Task1
{
    internal class Program
    {
        static void Main()
        {
            ProgressBar progressBar = new();
            List<Task> tasks = [
                progressBar.StartProgressBar(),
                progressBar.GetProgressInfo()
                ];

            while (tasks.Count > 0)
            {
                progressBar.GetProgressInfo().Wait();
                if (tasks[0].IsCompleted)
                {
                    break;
                }
            }
        }
    }
}
/*
 * Create a class ProgressBar that has an int field progress.
 * The main method of your applet should create an object of type
 * ProgressBar and execute a loop that increments the value of the
 * progress field by one every second until the value reaches 100.
 * Create another thread that outputs the value of the ProgressBar object,
 * the progress field, to the console every 3 seconds for as long as the program runs.
 */