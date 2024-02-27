using ManyToMany.DB;
using ManyToMany.Model;
using ManyToMany.Repository.Interface;

namespace ManyToMany.Repository
{
    internal class FileDBRepository : IFileDBRepository
    {
        private static readonly FileContext _context = new();

        public void SaveListOfFiles(List<FileDB> listOfFiles)
        {
            _context.FilesDB.AddRange(listOfFiles);
            _context.SaveChanges();
        }
    }
}
