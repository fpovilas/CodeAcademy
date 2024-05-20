namespace Notepad.Repository.Model
{
    public abstract class ImageBase
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string ContentType { get; set; }
        public required string PictureUrl { get; set; }
    }
}
