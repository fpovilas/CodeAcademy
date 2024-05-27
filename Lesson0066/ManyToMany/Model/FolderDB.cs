namespace ManyToMany.Model
{
    internal class FolderDB
    {
        public int Id { get; set; }
        public string? FolderName { get; set; }
        public List<FileDB>? Files { get; set; }
    }
}
