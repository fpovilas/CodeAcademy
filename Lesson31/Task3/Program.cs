namespace Task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PrintMenu();
            int choice = GetChoice();

            switch (choice)
            {
                case 1:
                    //var fileStream = 
                    break;
                case 2:
                    break;
                case 3:
                    break;
                default:
                    Console.WriteLine($"Something wen wrong... ({choice})");
                    break;

            }
        }

        private static void PrintMenu()
        {
            Console.WriteLine("""
                1. Read a large file using a custom buffer size and see what difference it made to the file's reading performance.
                2. Implement asynchronous file reading which does not block the main thread of the running application.
                3. Implement a file-based caching system that will store key-value pairs in a file and allow them to be efficiently extracted or written.
                    Use the FileStream class for efficient read control, potentially implementing indexing or other efficiency strategies.
                """);
        }

        private static int GetChoice()
        {
            Console.Write("Your choice: ");
            if (int.TryParse(Console.ReadLine(), out int choice))
            { return choice; }
            return 0;
        }
    }
}