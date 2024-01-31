using ExamAdvancedCSharp.Class;

namespace ExamAdvancedCSharp.Service
{
    internal class ReadFileService(string filePath, string fileName)
    {
        private readonly string filePath = filePath;
        private readonly string fileName = fileName;

        public List<T> ReadFile<T> ()
        {
            List<T> values = [];
            string fullPath = ConstructFullPath(filePath, fileName);

            using StreamReader streamReader = new(fullPath);
            List<string> list = [.. streamReader.ReadToEnd().Replace("\r\n", ";")
                                                .Split(';')
                                                .Where(itm => itm != string.Empty)];

            for (int i = 0; i < list.Count; i += 2)
            {
                if(typeof(T) == typeof(FoodItem))
                    values.Add((T)Convert.ChangeType(new FoodItem(list[i], Convert.ToDouble(list[i + 1])), typeof(T)));

                if (typeof(T) == typeof(DrinkItem))
                    values.Add((T)Convert.ChangeType(new DrinkItem(list[i], Convert.ToDouble(list[i + 1])), typeof(T)));
        }

            return values;
        }

        private static string ConstructFullPath(string filePath, string fileName)
        {
            if (filePath.Trim()[filePath.Length - 1] == '\\' )
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
