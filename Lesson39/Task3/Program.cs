namespace Task3
{
    internal class Program
    {
        static void Main()
        {
            string pathToALotOfFiles = @"D:\Users\Povka\Documents\Failai\";
            List<string> files = [.. Directory.GetFiles(pathToALotOfFiles)];

            Separator();
            //List<string> fileExtensions = files.Select(str => str.Substring(str.LastIndexOf('.'), str.Length - str.LastIndexOf('.'))).Distinct().ToList();
            PrintText("List of Files extensions: ");
            List<string> fileExtensions = files.Select(str => str[str.LastIndexOf('.')..]).Distinct().ToList();
            PrintList(fileExtensions);

            Separator();
            PrintText("List of Files with .jar extension: ");
            List<string> txtFileList = files.Where(str => str.EndsWith(".jar")).ToList();
            PrintList(txtFileList);

            Separator();
            PrintText("List of Files : ", true);
            List<string> onlyFileNames = files.Select(str => str.Replace(pathToALotOfFiles, "")).ToList();
            PrintList(onlyFileNames, true);
        }

        private static void PrintList<Type>(List<Type> list, bool printAsList = false)
        {
            if (printAsList)
            {
                foreach (Type type in list)
                {
                    Console.WriteLine(type);
                }
            }
            else
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (i < list.Count - 1)
                        Console.Write($"{list[i]}, ");
                    else { Console.WriteLine($"{list[i]}."); }
                }
            }
        }

        private static void PrintText(string text, bool printAsList = false)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            if(printAsList ) { Console.WriteLine(text); }
            else{ Console.Write(text); }
            Console.ResetColor();
        }

        private static void Separator()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------");
            Console.ResetColor();
        }
    }
}
/*
 * Find online functionality to get a list of files from a specified directory.
 *** Write LINQ functionality to get all file extensions (e.g. .txt, .csproj)
 *** Write LINQ functionality to retrieve all text files(.txt)
 *** Write LINQ functionality to get the names of all text files in the directory (only the filename must be present e.g. 'text.txt')
*/