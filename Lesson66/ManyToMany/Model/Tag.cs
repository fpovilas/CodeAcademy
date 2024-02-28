namespace ManyToMany.Model
{
    internal class Tag
    {
        public int Id { get; set; }
        public string? TagName { get; set; }
        public List<FileDB>? Files { get; set; }
    }
}
