using ManyToMany.DB;
using ManyToMany.Model;
using ManyToMany.Repository.Interface;

namespace ManyToMany.Repository
{
    internal class FolderDBRepository(FileContext context) : IFolderDBRepository
    {
        private readonly FileContext _context = context;

        public void SaveFolder(FolderDB folder)
        {
            _context.FoldersDB.Add(folder);
            _context.SaveChanges();
        }
    }
}