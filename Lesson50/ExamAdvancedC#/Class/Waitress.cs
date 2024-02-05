namespace ExamAdvancedCSharp.Class
{
    internal class Waitress(string name)
    {
        private string Name { get; set; } = name;
        private List<Table> Tables { get; set; } = [];

        public string GetName() => Name;
        public List<Table> GetTables() => Tables;

        public void AddTable(Table table) => Tables.Add(table);
    }
}
