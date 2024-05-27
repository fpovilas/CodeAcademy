using ManyToMany.DB;
using ManyToMany.Model;
using ManyToMany.Repository.Interface;

namespace ManyToMany.Repository
{
    internal class FileDBRepository(FileContext context) : IFileDBRepository
    {
        private readonly FileContext _context = context;

        public void SaveListOfFiles(List<FileDB> listOfFiles)
        {
            _context.FilesDB.AddRange(listOfFiles);
            _context.SaveChanges();
        }
    }
}
