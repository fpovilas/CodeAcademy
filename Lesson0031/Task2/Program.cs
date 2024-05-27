using System.Text;

namespace Task2
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
                    string task21Text = "Task2.1.txt";
                    IEnumerable<string> content = File.ReadLines(task21Text);
                    foreach(string item in content)
                    {
                        Console.WriteLine(item.Count());
                    }
                    break;
                case 2:
                    string text = "StreamWriter text";
                    int number = 985426;
                    using (StreamWriter writer = new("Task2.2.txt"))
                    {
                        writer.WriteLine(text);
                        writer.WriteLine(number);
                    }
                    break;
                case 3:
                    string tekstas = "Task 2 subtask 3";
                    using (BinaryWriter writer = new(File.Open("Task2.3.bin", FileMode.Create)))
                    {
                        writer.Write(tekstas);
                    }

                    using (BinaryReader reader = new(File.OpenRead("Task2.3.bin")))
                    {
                        Console.WriteLine(reader.ReadString());
                    }
                        break;
                default:
                    Console.WriteLine($"Something wen wrong... ({choice})");
                    break;

            }
        }

        private static void PrintMenu()
        {
            Console.WriteLine("""
                1. Read a large text file line by line and count the number of characters in each line. Use File.ReadLines()
                2. Write to a file using the StreamWriter class, write both textual and numeric data.
                3. Write the binary data to a file, try using BinaryReader and BinaryWriter
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