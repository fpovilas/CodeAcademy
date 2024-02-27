using ManyToMany.Model;

namespace ManyToMany.Repository.Interface
{
    internal interface IFileDBRepository
    {
        public void SaveListOfFiles(List<FileDB> listOfFiles);
    }
}
