using System.ComponentModel.DataAnnotations.Schema;

namespace ManyToMany.Model
{
    internal class FileDB
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public ulong? Size { get; set; }
        public string? FullPath { get; set; }
        public List<Tag>? Tags { get; set; }

        [ForeignKey("FolderDB")]
        public int? FolderDBID { get; set; }
    }
}
