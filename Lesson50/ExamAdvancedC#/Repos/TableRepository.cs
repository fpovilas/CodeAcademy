using ExamAdvancedCSharp.Class;
using ExamAdvancedCSharp.Repos.Interfaces;

namespace ExamAdvancedCSharp.Repos
{
    internal class TableRepository : ITableRepository
    {
        private static readonly string _pathToTables = @"D:\Projektai\Programavimas\CodeAcademy\Lesson50\Tables.txt";
        private static readonly List<Table> _tables = [];

        public TableRepository()
        {
            List<string> tables = GetList();

            LoadData(tables);
        }

        private static List<string> GetList()
        {
            using StreamReader reader = new(_pathToTables);
            List<string> tablesFile = reader.ReadToEnd()
                                            .Replace("\r\n", ";")
                                            .Split(';')
                                            .Where(tbl => tbl != string.Empty)
                                            .ToList();
            reader.Close();

            return tablesFile;
        }

        private static void LoadData(List<string> tables)
        {
            for(int i = 0; i < tables.Count; i += 2)
            {
                _tables.Add(new(tables[i], Convert.ToInt32(tables[i + 1])));
            }
        }

        public List<Table> GetTables() => _tables;
    }
}
