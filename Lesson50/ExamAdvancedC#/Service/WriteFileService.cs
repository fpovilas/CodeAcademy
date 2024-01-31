using ExamAdvancedCSharp.Class;

namespace ExamAdvancedCSharp.Service
{
    internal class WriteFileService(string filePath, string fileName)
    {
        private readonly string filePath = filePath;
        private readonly string fileName = fileName;

        public void WriteFile<T>(List<T> listOfValues)
        {
            string fullPath = ConstructFullPath(filePath, fileName);

            using StreamWriter streamWriter = new(fullPath, true);
            for (int i = 0; i < listOfValues.Count; i++)
            {
                streamWriter.WriteLine(listOfValues[i]);
            }
        }

        private static string ConstructFullPath(string filePath, string fileName)
        {
            if (filePath.Trim()[filePath.Length - 1] == '\\')
            {
                return (filePath + fileName);
            }
            else
            {
                return filePath + "/" + fileName;
            }
        }
    }
}