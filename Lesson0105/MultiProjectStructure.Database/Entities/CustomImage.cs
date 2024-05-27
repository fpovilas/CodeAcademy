namespace MultiProjectStructure.Database.Entities
{
    public class CustomImage
    {
        public Guid ID { get; set; }
        public required string Name { get; set; }
        public required string ContentType { get; set; }
        public required byte[] ImageData { get; set; }
        // public required string PictureUrl { get; set; } // for saving in PC/Server !use Absolute path to file!
    }
}