namespace Task1
{
    internal class Program
    {
        static void Main()
        {
            PrintMenu();
            int choice = GetChoice();

            switch (choice)
            {
                case 1:
                    string textFileContent = File.ReadAllText("Task1.1.txt");
                    Console.WriteLine(textFileContent);
                    break;
                case 2:
                    List<string> list = new()
                    {
                        "Text for Task1.2\n",
                        "Text for Subtask2 Task1\n",
                        "Text For Task\n"
                    };

                    string text = string.Empty;
                    foreach (string item in list)
                    {
                        text += item;
                        Console.Write(item);
                    }
                    File.WriteAllText("Task1.2.txt", text);
                    break;
                case 3:
                    string path = "Task1.1.txt";
                    string copyToPath = "CopyTo/Task1.3.txt";
                    File.Copy(path, copyToPath);
                    Console.WriteLine("Copying is done.");
                    break;
                default:
                    Console.WriteLine($"Something wen wrong... ({choice})");
                    break;

            }
        }

        private static void PrintMenu()
        {
            Console.WriteLine("""
                1. Read text using the File.ReadAllText() method and print it to the console.
                2. Write the contents of the List<string> list to the file, each item as a new string. Using File.WriteAllLines().
                3. Copy the file from one location to another using the File.Copy() method.
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