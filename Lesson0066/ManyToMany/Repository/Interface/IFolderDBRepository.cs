using ManyToMany.Model;

namespace ManyToMany.Repository.Interface
{
    internal interface IFolderDBRepository
    {
        public void SaveFolder(FolderDB folder);
    }
}
