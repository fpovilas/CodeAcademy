namespace FileUploadDownloadAPI.Model
{
    public class Image
    {
        public Guid ID { get; set; }
        public required string Name { get; set; }
        public required string ContentType { get; set; }
        public required string PictureUrl { get; set; }
        public required byte[] ImageData { get; set; }
    }
}
