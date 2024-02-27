using ManyToMany.Repository;
using ManyToMany.Repository.Interface;

namespace ManyToMany.Model
{
    internal static class ConsoleUI
    {
        public static void Run()
        {
            string? pathOfDir = GetDirectoryPath();

            try
            {
                if (!string.IsNullOrEmpty(pathOfDir))
                {
                    GetDirectoriesFromDirectory(pathOfDir);
                    List<FileDB> listOfFiles = GetFilesFromDirectory(pathOfDir);
                    PrintFiles(listOfFiles);
                    SaveFilesToDB(listOfFiles);
                }
                else { throw new Exception($"Directory not found [{pathOfDir}]"); }
            } catch (Exception ex)
            { Console.WriteLine(ex); }
        }

        private static string? GetDirectoryPath()
        {
            Console.WriteLine("Please enter path to directory:");

            string? directoryPath = Console.ReadLine();

            try
            {
                if (!string.IsNullOrEmpty(directoryPath))
                {
                    return directoryPath;
                }
                else { throw new Exception($"Directory not found [{directoryPath}]"); }
            } catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.ReadKey(true);
                return string.Empty;
            }
        }

        private static List<FileDB> GetFilesFromDirectory(string pathOfDir)
        {
            List<FileDB> listOfFiles = [];

            List<string> listOfFileString = [.. Directory.GetFiles(pathOfDir)];
            foreach (string fileString in listOfFileString)
            {
                FileInfo fileInfo = new(fileString);
                FileDB fileDB = new()
                {
                    FullPath = fileString,
                    Name = fileInfo.Name,
                    Size = (ulong)fileInfo.Length
                };
                listOfFiles.Add(fileDB);
            }

            return listOfFiles;
        }

        private static List<FolderDB> GetDirectoriesFromDirectory(string pathOfDir)
        {
            List<FolderDB> listOfDirectories = [];

            List<string> listOfDirectoriesString = [.. Directory.GetDirectories(pathOfDir)];
            foreach (string directoryString in listOfDirectoriesString)
            {
                FolderDB folderDB = new()
                {
                    Files = [],
                    FolderName = directoryString
                };
                listOfDirectories.Add(folderDB);
            }

            return listOfDirectories;
        }

        private static void PrintFiles(List<FileDB> listOfFiles)
        {
            foreach (FileDB fileDB in listOfFiles)
            {
                Console.WriteLine($"""
                    File Name: {fileDB.Name}
                    File Size: {fileDB.Size} B
                    File FullPath: {fileDB.FullPath}

                    """);
            }
        }

        private static void SaveFilesToDB(List<FileDB> listOfFiles)
        {
            FileDBRepository fileDBRepository = new();
            ((IFileDBRepository)fileDBRepository).SaveListOfFiles(listOfFiles);
        }
    }
}
