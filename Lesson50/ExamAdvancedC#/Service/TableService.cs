using ExamAdvancedCSharp.Service.Interfaces;
using ExamAdvancedCSharp.Repos;
using ExamAdvancedCSharp.Class;

namespace ExamAdvancedCSharp.Service
{
    internal class TableService() : ITableService
    {
        private static readonly TableRepository _tableRepository = new();

        public List<Table> GetTables() => _tableRepository.GetTables();
    }
}
