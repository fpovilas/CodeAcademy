using ExamAdvancedCSharp.Service.Interfaces;
using ExamAdvancedCSharp.Class;
using ExamAdvancedCSharp.Repos.Interfaces;

namespace ExamAdvancedCSharp.Service
{
    internal class TableService(ITableRepository tableRepository) : ITableService
    {
        private readonly ITableRepository _tableRepository = tableRepository;

        public List<Table> GetTables() => _tableRepository.GetTables();
    }
}
