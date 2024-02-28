using ManyToMany.DB;
using ManyToMany.Helpers;
using ManyToMany.Repository;
using ManyToMany.Repository.Interface;

namespace ManyToMany.Model
{
    internal class ConsoleUI
    {
        private readonly IFolderDBRepository folderDBRepository;
        private readonly IFileDBRepository fileDBRepository;
        private readonly ITagRepository tagRepository;

        public ConsoleUI()
        {
            FileContext _newContext = new();
            folderDBRepository = new FolderDBRepository(_newContext);
            fileDBRepository = new FileDBRepository(_newContext);
            tagRepository = new TagRepository(_newContext);
        }

        public void Run()
        {
            string? pathOfDir = GetDirectoryPath();

            try
            {
                if (!string.IsNullOrEmpty(pathOfDir))
                {
                    List<FileDB> listOfFiles = [];
                    bool stop = false;
                    do
                    {
                        Console.Write("(R)ecursive/(N)on-Recursive: ");
                        string? choice = Console.ReadLine();
                        if (!string.IsNullOrEmpty(choice))
                        {
                            switch (choice.ToLower())
                            {
                                case "r":
                                    List<FolderDB> listOfFolders = GetDirectoriesFromDirectory(pathOfDir);
                                    foreach (FolderDB folder in listOfFolders)
                                    {
                                        listOfFiles = GetFilesFromDirectory(folder.FolderName!);
                                        folder.Files = listOfFiles;
                                        AddFileTypeTag(listOfFiles);
                                        AddFileSizeTag(listOfFiles);
                                        PrintFiles(listOfFiles);
                                        SaveFolderToDB(folder);
                                    }
                                    stop = true;
                                    break;
                                case "n":
                                    listOfFiles = GetFilesFromDirectory(pathOfDir);
                                    AddFileTypeTag(listOfFiles);
                                    AddFileSizeTag(listOfFiles);
                                    PrintFiles(listOfFiles);
                                    SaveFilesToDB(listOfFiles);
                                    stop = true;
                                    break;
                                default:
                                    Console.WriteLine("Something went wrong");
                                    Console.ReadKey(true);
                                    break;
                            }
                        }
                    } while (!stop);
                }
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

        private List<FileDB> GetFilesFromDirectory(string pathOfDir)
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

        private List<FolderDB> GetDirectoriesFromDirectory(string pathOfDir)
        {
            List<string> allDirs = GetDirectoriesRecursively(pathOfDir);

            List<FolderDB> allDirsCorrectType = ConvertStringDirectoryList(allDirs);

            List<FolderDB> listOfDirectories = [];

            listOfDirectories.Add(new FolderDB() { Files = [], FolderName = pathOfDir });

            listOfDirectories.AddRange(allDirsCorrectType);
            
            return listOfDirectories;
        }

        private List<string> GetDirectoriesRecursively(string pathOfDir)
        {
            List<string> listOfDirectories = [];

            List<string> listOfDirectoriesInitial = [.. Directory.GetDirectories(pathOfDir)];

            listOfDirectories.AddRange(listOfDirectoriesInitial);

            foreach (string dir in listOfDirectoriesInitial)
            {
                listOfDirectories.AddRange(GetDirectoriesRecursively(dir));
            }

            return listOfDirectories;
        }

        private List<FolderDB> ConvertStringDirectoryList(List<string> listOfDirectories)
        {
            List<FolderDB> listOfFolders = [];

            foreach (string directoryString in listOfDirectories)
            {
                FolderDB folderDB = new()
                {
                    Files = [],
                    FolderName = directoryString
                };
                listOfFolders.Add(folderDB);
            }

            return listOfFolders;
        }

        private static void PrintFiles(List<FileDB> listOfFiles)
        {
            foreach (FileDB fileDB in listOfFiles)
            {
                Console.WriteLine($"""
                    File Name: {fileDB.Name}
                    File Size: {fileDB.Size} B
                    File FullPath: {fileDB.FullPath}
                    File Tags: {
                    (fileDB.Tags != null ?
                        string.Join(" ", fileDB.Tags.Select(tag => tag.TagName)) :
                              "Empty")}
                    """);
            }
        }

        private void AddFileTypeTag(List<FileDB> listOfFiles)
        {
            foreach(FileDB fileDB in listOfFiles)
            {
                string? filePath = fileDB.FullPath;
                if(!string.IsNullOrEmpty(filePath))
                {
                    string fileExtension = new FileInfo(filePath).Extension.Trim('.').ToUpper();

                    if (FileTypes.Music.Types.Contains(fileExtension)) { AddMusicTag(fileDB); }
                    else if (FileTypes.Document.Types.Contains(fileExtension)) { AddDocumentTag(fileDB); }
                    else if (FileTypes.Picture.Types.Contains(fileExtension)) { AddPictureTag(fileDB); }
                    else if (FileTypes.Video.Types.Contains(fileExtension)) { AddVideoTag(fileDB); }
                    else if (FileTypes.File.Types.Contains(fileExtension)) { AddFileTag(fileDB); }
                    else { AddOtherTag(fileDB); }
                }

            }
        }

        private void AddFileSizeTag(List<FileDB> listOfFiles)
        {
            foreach (FileDB fileDB in listOfFiles)
            {
                string? filePath = fileDB.FullPath;
                if (!string.IsNullOrEmpty(filePath))
                {
                    long fileSize = new FileInfo(filePath).Length;

                    if (fileSize <= SizeType.SmallFile) { AddSmallFileTag(fileDB); }
                    else if (fileSize > SizeType.SmallFile && fileSize <= SizeType.BigFile)
                        { AddMediumFileTag(fileDB); }
                    else { AddBigFileTag(fileDB); }
                }

            }
        }

        private void AddMusicTag(FileDB fileDB)
        {
            Tag musicTag = tagRepository.GetTag(nameof(FileTypes.Music));

            if (fileDB.Tags != null)
                fileDB.Tags.Add(musicTag);
            else
            {
                fileDB.Tags = [];
                fileDB.Tags.Add(musicTag);
            }
        }

        private void AddDocumentTag(FileDB fileDB)
        {
            Tag documentTag = tagRepository.GetTag(nameof(FileTypes.Document).ToString());

            if (fileDB.Tags != null)
                fileDB.Tags.Add(documentTag);
            else
            {
                fileDB.Tags = [];
                fileDB.Tags.Add(documentTag);
            }
        }

        private void AddPictureTag(FileDB fileDB)
        {
            Tag pictureTag = tagRepository.GetTag(nameof(FileTypes.Picture).ToString());

            if (fileDB.Tags != null)
                fileDB.Tags.Add(pictureTag);
            else
            {
                fileDB.Tags = [];
                fileDB.Tags.Add(pictureTag);
            }
        }

        private void AddVideoTag(FileDB fileDB)
        {
            Tag videoTag = tagRepository.GetTag(nameof(FileTypes.Video).ToString());

            if (fileDB.Tags != null)
                fileDB.Tags.Add(videoTag);
            else
            {
                fileDB.Tags = [];
                fileDB.Tags.Add(videoTag);
            }
        }

        private void AddFileTag(FileDB fileDB)
        {
            Tag fileTag = tagRepository.GetTag(nameof(FileTypes.File).ToString());

            if (fileDB.Tags != null)
                fileDB.Tags.Add(fileTag);
            else
            {
                fileDB.Tags = [];
                fileDB.Tags.Add(fileTag);
            }
        }

        private void AddOtherTag(FileDB fileDB)
        {
            Tag otherTag = tagRepository.GetTag("Other");

            if (fileDB.Tags != null)
                fileDB.Tags.Add(otherTag);
            else
            {
                fileDB.Tags = [];
                fileDB.Tags.Add(otherTag);
            }
        }

        private void AddSmallFileTag(FileDB fileDB)
        {
            Tag smallFileTag = tagRepository.GetTag(nameof(SizeType.SmallFile));

            if (fileDB.Tags != null)
                fileDB.Tags.Add(smallFileTag);
            else
            {
                fileDB.Tags = [];
                fileDB.Tags.Add(smallFileTag);
            }
        }

        private void AddMediumFileTag(FileDB fileDB)
        {
            Tag mediumFileTag = tagRepository.GetTag("MediumFile");

            if (fileDB.Tags != null)
                fileDB.Tags.Add(mediumFileTag);
            else
            {
                fileDB.Tags = [];
                fileDB.Tags.Add(mediumFileTag);
                }
        }

        private void AddBigFileTag(FileDB fileDB)
        {
            Tag bigFileTag = tagRepository.GetTag(nameof(SizeType.BigFile));

            if (fileDB.Tags != null)
                fileDB.Tags.Add(bigFileTag);
            else
            {
                fileDB.Tags = [];
                fileDB.Tags.Add(bigFileTag);
            }
        }

        private void SaveFilesToDB(List<FileDB> listOfFiles) => fileDBRepository.SaveListOfFiles(listOfFiles);

        private void SaveFolderToDB(FolderDB folder)
        {
            folderDBRepository.SaveFolder(folder);
        }
    }
}
